using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Utils;

namespace SearchAlgorithmBenchmarker
{

    public partial class Form1 : Form
    {
        private const string _saveFileDirectory = @".\..\..\..\Test Results";
        private int[] _values;

        private Dictionary<string, RichTextBox> _outputTextBoxes;
        private const int _numSortTests = 85;
        private const int _numSearchTests = 15;
        private const int _arrayGrowthConst = 350;
        private int _sortSize;
        public Form1()
        {
            InitializeComponent();
            _outputTextBoxes = new Dictionary<string, RichTextBox>();
            _outputTextBoxes.Add(tbBenchmarkSelector.TabPages[0].Name, txtOutput);
            _outputTextBoxes.Add(tbBenchmarkSelector.TabPages[1].Name, txtOutput2);
        }

        private void ReportProgress(ProgressData d)
        {
            pbTaskProgress.Value = (int)d.PercentComplete * 100;
            if (d.PercentComplete > 25 && d.PercentComplete < (25 + float.Epsilon))
            {
                IO.Print(_outputTextBoxes[tbBenchmarkSelector.SelectedTab.Name], "Task at 25% completion");
            }
            else if (d.PercentComplete > 50 && d.PercentComplete < (50 + float.Epsilon))
            {
                IO.Print(_outputTextBoxes[tbBenchmarkSelector.SelectedTab.Name], "Task at 50% completion");
            }
            else if (d.PercentComplete > 75 && d.PercentComplete < (75 + float.Epsilon))
            {
                IO.Print(_outputTextBoxes[tbBenchmarkSelector.SelectedTab.Name], "Task at 75% completion");
            }

            if (!string.IsNullOrWhiteSpace(d.ActionCompleted))
            {
                IO.Print(_outputTextBoxes[tbBenchmarkSelector.SelectedTab.Name], d.ActionCompleted);
            }
        }

        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            var progressMonitor = new Progress<ProgressData>(d => ReportProgress(d));

            if (progressMonitor != null)
            {
                var arraySize = 0;
                if (!IO.ParseInt(txtInput, ref arraySize) || arraySize < 10000 || arraySize > 10000000)
                {
                    IO.SetWarningText(lblWarning, Color.Red, "Invalid value entered!");
                    return;
                }
                if (cbAdditiveArray.Checked)
                {
                    int arrSize = Common.Sum(1, arraySize / _arrayGrowthConst);
                    generateArrayAsync(arrSize * _arrayGrowthConst, lblWarning, txtOutput, progressMonitor);
                }
                else
                {
                    generateArrayAsync(arraySize, lblWarning, txtOutput, progressMonitor);
                }

            }
            else
            {
                var arraySize = 0;
                if (!IO.ParseInt(txtInput, ref arraySize) || arraySize < 10000 || arraySize > 10000000)
                {
                    IO.SetWarningText(lblWarning, Color.Red, "Invalid value entered!");
                    return;
                }
                generateArray(arraySize, lblWarning, txtOutput);
            }

        }

        private void generateArray(int arrSize, Label lblWarn, RichTextBox txtOut)
        {

            IO.ResetWarningText(lblWarn);
            var ag = new ArrayGenerator(arrSize, 1000, 10000);
            IO.Print(txtOut, "Attempting to generate array...");
            _values = ag.GenerateArray();

            IO.Print(txtOut, $"Array of {ag.arraySize} values generated successfully.\n" +
                                $"Array has lower bound of {ag.lowBound} and higher bound of {ag.highBound}.");
        }

        private async void generateArrayAsync(int arrSize, Label lblWarn, RichTextBox txtOut, IProgress<ProgressData> progress = null)
        {
            IO.ResetWarningText(lblWarn);
            var ag = new ArrayGenerator(arrSize, 1000, 10000);
            //IO.Print(txtOut, "Attempting to generate array...");
            var startTicks = DateTime.Now.Ticks;
            _values = await ag.GetArrayAsync(progress);

            var ticksTaken = DateTime.Now.Ticks - startTicks;
            IO.Print(txtOut, $"Array of {ag.arraySize} values generated successfully - Time taken to generate array: {TimeSpan.FromTicks(ticksTaken).TotalSeconds}s\n" +
                             $"Array has lower bound of {ag.lowBound} and higher bound of {ag.highBound}.");
            pbTaskProgress.Value = 0;

        }

        private void cmdSort_Click(object sender, EventArgs e)
        {
            var progressMonitor = new Progress<ProgressData>(d => ReportProgress(d));

            if (cbAdditiveArray.Checked)
            {
                int outSize = 0;
                if (!IO.ParseInt(txtInput, ref outSize))
                {
                    IO.SetWarningText(lblWarning, "No array size parameter in text field!");
                    return;
                }
                RunAdditiveSearchBenchmarkAsync(progressMonitor, outSize);
            }
            else
            {
                runSearchBenchmarkAsync(progressMonitor);
            }
        }

        private void runSearchBenchmark()
        {
            if (_values == null)
            {
                IO.SetWarningText(lblWarning, Color.Red, "Array of numbers must be generated before benchmarking can be run!");
                return;
            }
            // summary statistics
            int numSucc = 0, numFail = 0, numTests = _values.Length / 2;
            long avgTicksItr, avgTicksRec;
            long sumTicksItr = 0, sumTicksRec = 0;
            // float hitRate;

            var valueToFind = 0;
            /*
            if (!IO.ParseInt(txtInput2, ref valueToFind))
            {
                IO.SetWarningText(lblWarning, "Value to be found must be entered before searching algorithms can be run!";
                return;
            }
            */

            IO.ResetWarningText(lblWarning);
            Array.Sort(_values);
            IO.Print(txtOutput, "Commence benchmarking...");
            for (int x = 0; x < numTests; x++)
            {
                var startTime = DateTime.Now.Ticks;
                valueToFind = Common.GetRandomValue(1000, 10000);

                // IO.Print(txtOutput, "Running recursive binary search algorithm...");

                // run recursive search
                var inx = 0;
                try
                {
                    inx = SearchAlgorithms.RecursiveBinarySearch(_values, valueToFind, (_values.Length - 1), 0);
                }
                catch (StackOverflowException ex)
                {
                    IO.Print(txtOutput, "Encountered stack overflow while performing recursive search.");
                }
                var timeTaken = DateTime.Now.Ticks - startTime;
                if (inx == -1)
                {
                    numFail++;
                    // IO.Print(txtOutput, "Failed to find value in array using recursive search.");
                }
                else
                {
                    numSucc++;
                    // IO.Print(txtOutput, $"Successfully found value in array using recursive search at index {inx}.");
                }
                // IO.Print(txtOutput, $"Time taken in ticks: {timeTaken}");
                sumTicksRec += timeTaken;

                // reset start time, run iterative search
                startTime = DateTime.Now.Ticks;
                // IO.Print(txtOutput, "Running iterative binary search algorithm...");
                inx = SearchAlgorithms.IterativeBinarySearch(_values, valueToFind);
                timeTaken = DateTime.Now.Ticks - startTime;
                if (inx == -1)
                {
                    numFail++;
                    // IO.Print(txtOutput, "Failed to find value in array using iterative search.");
                }
                else
                {
                    numSucc++;
                    // IO.Print(txtOutput, $"Successfully found value in array using iterative search at index {inx}.");
                }
                sumTicksItr += timeTaken;
                // IO.Print(txtOutput, $"Time taken in ticks: {timeTaken}");
            }

            avgTicksItr = Common.CalculateAverage(sumTicksItr, numTests);
            avgTicksRec = Common.CalculateAverage(sumTicksRec, numTests);
            IO.Print(txtOutput, $"Benchmarking completed.\nTotal time taken in ticks: {sumTicksItr + sumTicksRec}");
            IO.Print(txtOutput, $"Percentage values found: {((float)numSucc / (numSucc + numFail) * 100)}%");
            IO.Print(txtOutput, $"Average no. ticks for recursive search: {avgTicksRec}\nAverage no. ticks for iterative search: {avgTicksItr}");

        }

        private async void runSearchBenchmarkAsync(IProgress<ProgressData> progress)
        {
            if (_values == null)
            {
                IO.SetWarningText(lblWarning, Color.Red, "Array of numbers must be generated before benchmarking can be run!");
                return;
            }
            // summary statistics
            int numSucc = 0, numTests = _values.Length / 10;
            long avgTicksItr, avgTicksRec;
            long sumTicksItr = 0, sumTicksRec = 0;

            // Progress report
            var report = new ProgressData();

            var valueToFind = 0;
            /*
            if (!IO.ParseInt(txtInput2, ref valueToFind))
            {
                IO.SetWarningText(lblWarning, "Value to be found must be entered before searching algorithms can be run!";
                return;
            }
            */

            IO.ResetWarningText(lblWarning);
            Array.Sort(_values);
            IO.Print(txtOutput, "Commence benchmarking...");
            List<List<long>> testTimes = new List<List<long>>();
            testTimes.Add(new List<long>());
            testTimes.Add(new List<long>());
            TaskSummary<int> summary = null;
            for (int x = 0; x < numTests; x++)
            {
                var startTime = DateTime.Now.Ticks;
                valueToFind = Common.GetRandomValue(1000, 10000);

                // run recursive search
                var inx = 0;
                try
                {
                    summary = await SearchAlgorithms.RecursiveBinarySearchAsync(_values, valueToFind, (_values.Length - 1), 0);
                    inx = summary.Data;
                }
                catch (StackOverflowException)
                {
                    IO.Print(txtOutput, "Encountered stack overflow while performing recursive search.");
                }
                var timeTaken = summary?.TicksElapsed ?? 0;

                numSucc = (inx == -1) ? numSucc : numSucc + 1;
                testTimes[0].Add(timeTaken);
                sumTicksRec += timeTaken;

                // reset start time, run iterative search
                startTime = DateTime.Now.Ticks;
                summary = await SearchAlgorithms.IterativeBinarySearchAsync(_values, valueToFind, _values.Length - 1, 0);
                inx = summary.Data;
                timeTaken = summary.TicksElapsed;

                numSucc = (inx == -1) ? numSucc : numSucc + 1;
                sumTicksItr += timeTaken;
                testTimes[1].Add(timeTaken);
                report.PercentComplete = (float)((x * 100) / numTests);
                progress.Report(report);
            }

            var option = MessageBox.Show("Benchmarking complete. would you like to save the results?", "Test complete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            bool? result = null;
            if (option == DialogResult.Yes)
            {
                result = await saveSearchTestResultsAsync(testTimes);
            }
            if (result == true)
            {
                IO.Print(txtOutput, $"Test results successfully saved. To see them, check out the \"Test Results\" directory.\nTotal time taken: {TimeSpan.FromTicks(sumTicksItr + sumTicksRec).TotalSeconds}s");
            }
            else if (result == null)
            {
                avgTicksItr = Common.CalculateAverage(sumTicksItr, numTests);
                avgTicksRec = Common.CalculateAverage(sumTicksRec, numTests);
                IO.Print(txtOutput, $"Benchmarking completed.\nTotal time taken: {TimeSpan.FromTicks(sumTicksItr + sumTicksRec).TotalSeconds}s");
                IO.Print(txtOutput, $"Percentage values found: {(float)(numSucc / numTests) * 100}%");
                IO.Print(txtOutput, $"Average ms for recursive search: {TimeSpan.FromTicks(avgTicksRec).TotalMilliseconds}\nAverage ms for iterative search: {TimeSpan.FromTicks(avgTicksItr).TotalMilliseconds}");
                pbTaskProgress.Value = 0;
            }
            else
            {
                IO.SetWarningText(lblWarning, "Failed to save test results.");
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            IO.Clear(txtOutput);
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = MessageBox.Show("The array generated will be cleared if you do this.\nAre you sure?", "Notification", MessageBoxButtons.YesNo);
            if (dlgResult == DialogResult.Yes)
            {
                _values = null;
                IO.Clear(txtOutput);
                IO.Clear(txtOutput2);
            }
            else if (dlgResult == DialogResult.No)
            {
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IO.ResetWarningText(lblWarning);
            IO.ResetWarningText(lblWarning2);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            return;
        }

        private void cmdGenerate2_Click(object sender, EventArgs e)
        {
            var progressMonitor = new Progress<ProgressData>();
            progressMonitor.ProgressChanged += (s, x) => { pbTaskProgress.Value = (int)(x.PercentComplete) * 100; };

            var arraySize = 0;
            if (!IO.ParseInt(txtInput3, ref arraySize) || arraySize < 850 || arraySize > 12500)
            {
                IO.SetWarningText(lblWarning2, Color.Red, "Invalid value entered!");
                return;
            }
            _sortSize = arraySize;
            generateArrayAsync(arraySize * _numSortTests, lblWarning2, txtOutput2, progressMonitor);
        }

        private void cmdBenchmark_Click(object sender, EventArgs e)
        {
            var reporter = new Progress<ProgressData>(d => ReportProgress(d));

            runSortBenchmarkAsync(reporter);
        }

        private void runSortBenchmark()
        {
            if (_values == null)
            {
                IO.SetWarningText(lblWarning, Color.Red, "Array of numbers must be generated before benchmarking can be run!");
                return;
            }
            if (_values.Length < 150 || _values.Length > 1500)
            {
                IO.SetWarningText(lblWarning2, Color.DarkOrange, "Size of array isn't within accepted range.\nPlease re-enter values.");
                return;
            }
            // summary statistics
            int numSucc = 0, numFail = 0, numTests = _values.Length / 2;
            long avgTicksMrg, avgTicksHep;
            long sumTicksMrg = 0, sumTicksHep = 0;

            var valueToFind = 0;

            IO.ResetWarningText(lblWarning);
            // Array.Sort(_values);
            IO.Print(txtOutput2, "Commence benchmarking...");
            for (int x = 0; x < numTests; x++)
            {

                _values = Common.ShuffleArray(_values);
                var startTime = DateTime.Now.Ticks;
                _values = SortAlgorithms.MergeSort(_values);
                var timeTaken = DateTime.Now.Ticks - startTime;
                sumTicksMrg += timeTaken;

                // reset start time, run heapsort
                _values = Common.ShuffleArray(_values);
                startTime = DateTime.Now.Ticks;
                _values = SortAlgorithms.HeapSort(_values);
                timeTaken = DateTime.Now.Ticks - startTime;
                sumTicksHep += timeTaken;
            }

            avgTicksMrg = Common.CalculateAverage(sumTicksMrg, numTests);
            avgTicksHep = Common.CalculateAverage(sumTicksHep, numTests);
            IO.Print(txtOutput2, $"Benchmarking completed.\nTotal time taken in ticks: {sumTicksMrg + sumTicksHep}");
            // IO.Print(txtOutput, $"Percentage values found: {((float)numSucc / (numSucc + numFail) * 100)}%");
            IO.Print(txtOutput2, $"Average no. ticks for mergesort: {avgTicksMrg}\nAverage no. ticks for heapsort: {avgTicksHep}");
        }

        private async void runSortBenchmarkAsync(IProgress<ProgressData> progress)
        {
            if (_values == null)
            {
                IO.SetWarningText(lblWarning, Color.Red, "Array of numbers must be generated before benchmarking can be run!");
                return;
            }
            //if (_values.Length < 150 || _values.Length > 1500)
            //{
            //    IO.SetWarningText(lblWarning2, Color.DarkOrange, "Size of array isn't within accepted range.\nPlease re-enter values.");
            //    return;
            //}

            IO.ResetWarningText(lblWarning2);
            // ProgressData pData = new ProgressData();
            int[][] testValues = new int[4][];
            List<List<long>> testTimes = new List<List<long>>();
            for (int i = 0; i < 3; i++)
            {
                testValues[i] = new int[_sortSize * _numSortTests];
                testTimes.Add(new List<long>());
                Array.Copy(_values, testValues[i], _values.Length);
            }

            int numTests = _numSortTests;
            // summary stats

            long sumTimeMg = 0, sumTimeHp = 0, sumTimeQk = 0, sumTimeQk2 = 0;
            long avgTicksMg = 0, avgTicksHp = 0, avgTicksQk = 0, avgTicksQk2 = 0;
            long maxTicksMg = 0, maxTicksHp = 0, maxTicksQk = 0, maxTicksQk2 = 0;
            var pData = new ProgressData { ActionCompleted = "Commencing sort..." };
            progress.Report(pData);
            long minTicksMg = long.MaxValue, minTicksHp = long.MaxValue, minTicksQk = long.MaxValue, minTicksQk2 = long.MaxValue;
            for (int c = 0; c < numTests; c++)
            {
                var summary = await SortAlgorithms.QuickSortAsnyc(testValues[0], c * _sortSize, (c * _sortSize) + (_sortSize - 1));
                testValues[0] = summary.Data;
                testTimes[0].Add(summary.TicksElapsed);
                sumTimeQk += summary.TicksElapsed;
                if (maxTicksQk < summary.TicksElapsed)
                {
                    maxTicksQk = summary.TicksElapsed;
                }
                if (minTicksQk > summary.TicksElapsed)
                {
                    minTicksQk = summary.TicksElapsed;
                }

                summary = await SortAlgorithms.QuickSortAsnyc2(testValues[1], c * _sortSize, (c * _sortSize) + (_sortSize - 1));
                testValues[1] = summary.Data;
                testTimes[1].Add(summary.TicksElapsed);
                sumTimeQk2 += summary.TicksElapsed;
                if (maxTicksQk2 < summary.TicksElapsed)
                {
                    maxTicksQk2 = summary.TicksElapsed;
                }
                if (minTicksQk2 > summary.TicksElapsed)
                {
                    minTicksQk2 = summary.TicksElapsed;
                }
                pData.PercentComplete = (numTests / 50) * 100;
                progress.Report(pData);

                summary = await SortAlgorithms.HeapSortAsync2(testValues[2], c * _sortSize, (c * _sortSize) + (_sortSize - 1));
                testValues[2] = summary.Data;
                testTimes[2].Add(summary.TicksElapsed);
                sumTimeHp += summary.TicksElapsed;
                if (maxTicksHp < summary.TicksElapsed)
                {
                    maxTicksHp = summary.TicksElapsed;
                }
                if (minTicksHp > summary.TicksElapsed)
                {
                    minTicksHp = summary.TicksElapsed;
                }
                pData.PercentComplete = (c * 100) / _numSortTests;
                progress.Report(pData);
            }

            avgTicksQk = sumTimeQk / numTests;
            avgTicksQk2 = sumTimeQk2 / numTests;
            avgTicksHp = sumTimeHp / numTests;

            var option = MessageBox.Show("Testing completed. would you like to save the testing results?", "Testing complete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            bool? result = null;
            if (option == DialogResult.Yes)
            {
                result = await saveSortTestResultsAsync(testTimes);
            }
            if (result == true)
            {
                IO.Print(txtOutput2, $"Test results successfully saved. To see them, check out the \"Test Results\" directory.\nTotal time taken: {TimeSpan.FromTicks(sumTimeHp + sumTimeQk + sumTimeQk2).TotalSeconds}s");
            }
            else if (result == null)
            {
                TimeSpan totalTimeQk = TimeSpan.FromTicks(sumTimeQk), totalTimeQk2 = TimeSpan.FromTicks(sumTimeQk2);
                TimeSpan AvgTimeQk = TimeSpan.FromTicks(avgTicksQk), AvgTimeQk2 = TimeSpan.FromTicks(avgTicksQk2);
                TimeSpan maxTimeQk = TimeSpan.FromTicks(maxTicksQk), maxTimeQk2 = TimeSpan.FromTicks(maxTicksQk2);
                TimeSpan minTimeQk = TimeSpan.FromTicks(minTicksQk), minTimeQk2 = TimeSpan.FromTicks(minTicksQk2);
                TimeSpan totalTimeHp = TimeSpan.FromTicks(sumTimeHp), AvgTimeHp = TimeSpan.FromTicks(avgTicksHp), maxTimeHp = TimeSpan.FromTicks(maxTicksHp), minTimeHP = TimeSpan.FromTicks(minTicksHp);
                string testOutput = $"Testing complete. Summary statistics below:\nTotal Time taken: {(totalTimeQk + totalTimeQk2).TotalSeconds}s\nAverage for standard quicksort: {AvgTimeQk.TotalMilliseconds}ms\nAverage for optimised quicksort: {AvgTimeQk2.TotalMilliseconds}ms\nAverage for heapsort: {AvgTimeHp.TotalMilliseconds}ms\nMax time for standard quicksort: {maxTimeQk.TotalMilliseconds}ms\nMax time for optimised quicksort: {maxTimeQk2.TotalMilliseconds}ms\nMax time for heapsort: {maxTimeHp.TotalMilliseconds}ms\nMin time for standard quicksort: {minTimeQk.TotalMilliseconds}ms\nMin time for optimised quicksort: {minTimeQk2.TotalMilliseconds}ms\nMin time for heapsort: {minTimeHP.TotalMilliseconds}ms";
                IO.Print(txtOutput2, testOutput);
            }
            else
            {
                IO.SetWarningText(lblWarning2, "Failed to save test results.");
            }
        }

        private async Task<bool> saveSortTestResultsAsync(List<List<long>> testTimes)
        {
            return await Task.Run(async () =>
            {
                string fileName = $"tst_srt{DateTime.Today.Day}-{DateTime.Today.Month}-{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.csv";
                string filePath = Path.Combine(_saveFileDirectory, fileName);
                StringBuilder sb = new StringBuilder();
                sb.Append("Quicksort1 time(ticks),Quicksort2 time(ticks),Heapsort time(ticks)\n");
                for (int i = 0; i < _numSortTests; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        sb.Append(testTimes[j][i] + ",");
                    }
                    sb.Append("\n");
                }
                try
                {
                    using (Stream s = File.Open(filePath, FileMode.Create))
                    using (StreamWriter sr = new StreamWriter(s))
                    {
                        await sr.WriteAsync(sb.ToString());
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            });

        }

        private async Task<bool> saveSearchTestResultsAsync(List<List<long>> testTimes)
        {
            return await Task.Run(async () =>
            {
                string fileName = $"tst_sch{DateTime.Today.Day}-{DateTime.Today.Month}-{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.csv";
                string filePath = Path.Combine(_saveFileDirectory, fileName);
                int len = _values.Length / 10;
                StringBuilder sb = new StringBuilder();
                sb.Append("Recursive search time(ticks),Iterative search time(ticks)\n");
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        sb.Append(testTimes[j][i] + ",");
                    }
                    sb.Append("\n");
                }
                try
                {
                    using (Stream s = File.Open(filePath, FileMode.Create))
                    using (StreamWriter sr = new StreamWriter(s))
                    {
                        await sr.WriteAsync(sb.ToString());
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            });

        }

        private void cmdClear2_Click(object sender, EventArgs e)
        {
            IO.Clear(txtOutput2);
            IO.ResetWarningText(lblWarning);
            // Array.Sort(_values);
            IO.Print(txtOutput2, "Commence benchmarking...");
        }

        private async Task<int[]> GetValuesAsync(int num, int lo, int hi, IProgress<ProgressData> progressMonitor)
        {
            return await new ArrayGenerator(num, 1000, 10000).GetArrayAsync(progressMonitor);
        }

        private async void RunAdditiveSearchBenchmarkAsync(IProgress<ProgressData> progressMonitor, int outSize)
        {
            IO.ResetWarningText(lblWarning);
            //var progressMonitor = new Progress<ProgressData>(d => ReportProgress(d));
            //int outSize = 0;
            List<long[]> resultsRec = new List<long[]>();
            List<long[]> resultsIter = new List<long[]>();

            var testVals = await GetValuesAsync(outSize + (_numSearchTests) / _arrayGrowthConst, 1000, 10000, progressMonitor);
            Array.Sort(_values);
            Array.Sort(testVals);
            int a = 0;
            long maxIter = 0, minIter = long.MaxValue, maxRec = 0, minRec = long.MaxValue, sumTime = 0;
            int numTests = outSize / _arrayGrowthConst;
            int numSucc = 0;
            ProgressData pd = new ProgressData();
            pd.ActionCompleted = "Commencing additive benchmark...";
            progressMonitor.Report(pd);
            pd.ActionCompleted = string.Empty;
            TaskSummary<int> summary;
            for (int i = 1; i < numTests; i++)
            {
                long ticksTaken;
                resultsRec.Add(new long[_numSearchTests]);
                resultsIter.Add(new long[_numSearchTests]);
                int m = 0;
                for (m = 0; m < _numSearchTests; m++)
                {
                    summary = await SearchAlgorithms.RecursiveBinarySearchAsync(_values, testVals[((i - 1) * _numSearchTests) + m], ((a + i) * _arrayGrowthConst) - 1, a * _arrayGrowthConst);
                    ticksTaken = summary.TicksElapsed;
                    numSucc = (summary.Data > -1) ? numSucc + 1 : numSucc;
                    sumTime += ticksTaken;
                    if (ticksTaken < minRec)
                    {
                        minRec = ticksTaken;
                    }
                    else if (ticksTaken > maxRec)
                    {
                        maxRec = ticksTaken;
                    }
                    resultsRec[i - 1][m] = ticksTaken;
                }

                for (m = 0; m < _numSearchTests; m++)
                {
                    summary = await SearchAlgorithms.IterativeBinarySearchAsync(_values, testVals[((i - 1) * _numSearchTests) + m], ((a + i) * _arrayGrowthConst) - 1, a * _arrayGrowthConst);
                    ticksTaken = summary.TicksElapsed;
                    numSucc = (summary.Data > -1) ? numSucc + 1 : numSucc;
                    sumTime += ticksTaken;
                    if (ticksTaken < minIter)
                    {
                        minIter = ticksTaken;
                    }
                    else if (ticksTaken > maxIter)
                    {
                        maxIter = ticksTaken;
                    }
                    resultsIter[i - 1][m] = ticksTaken;
                }


                a += i;
                pd.PercentComplete = ((i - 1) * 100) / numTests;
                progressMonitor.Report(pd);
            }
            pd.ActionCompleted = "Additive benchmark complete.";
            progressMonitor.Report(pd);

            var option = MessageBox.Show("Testing completed. would you like to save the testing results?", "Testing complete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            bool? result = null;
            if (option == DialogResult.Yes)
            {
                var statsRec = await prepareStatistics(resultsRec);
                var statsIter = await prepareStatistics(resultsIter);
                result = await saveAdditiveSearchResultsAsync(statsRec, statsIter, numTests - 1);
            }
            if (result == true)
            {
                IO.Print(txtOutput, $"Test results successfully saved. To see them, check out the \"Test Results\" directory.\nTotal time taken: {TimeSpan.FromTicks(sumTime).TotalSeconds}s");
            }
            else if (result == null)
            {
                string summaryStats = $"Total time taken: {TimeSpan.FromTicks(sumTime).TotalSeconds}s\nPercentage values found: {(float)((numSucc * 100) / numTests)}%\n" + $"Maximum time for recursive search: {TimeSpan.FromTicks(maxRec).TotalMilliseconds}ms\nMinimum time for recursive search: {TimeSpan.FromTicks(minRec).TotalMilliseconds}ms\n" +
                            $"Maximum time for iterative search: {TimeSpan.FromTicks(maxIter).TotalMilliseconds}ms\nMinimum time for recursive search: {TimeSpan.FromTicks(minIter).TotalMilliseconds}ms";
                IO.Print(txtOutput, summaryStats);
            }
        }

        private async Task<long[][]> prepareStatistics(List<long[]> summaryStats)
        {
            var ret = await Task.Run(() =>
            {
                long[][] retArr = new long[summaryStats.Count][];
                for (int i = 0; i < summaryStats.Count; i++)
                {
                    retArr[i] = new long[3];
                    retArr[i][0] = Common.Sum(summaryStats[i]) / _numSearchTests;
                    retArr[i][1] = summaryStats[i].Max();
                    retArr[i][2] = summaryStats[i].Min();
                }
                return retArr;
            });
            return ret;
        }

        private async Task<bool> saveAdditiveSearchResultsAsync(long[][] statsRec, long[][] statsIter, int numStatistics)
        {
            return await Task.Run(async () =>
            {
                string fileName = $"tst_add-sch{DateTime.Today.Day}-{DateTime.Today.Month}-{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.csv";
                string filePath = Path.Combine(_saveFileDirectory, fileName);
                StringBuilder sb = new StringBuilder();
                sb.Append("Array size,Avg. recursive search time (ms),Max. recursive search time(ms),Min. recursive search time (ms)\n");
                for (int c = 0; c < numStatistics; c++)
                {
                    sb.Append($"{((c + 1) * _arrayGrowthConst)},{statsRec[c][0]},{statsRec[c][1]},{statsRec[c][2]}\n");
                }
                sb.Append("\n\n\n");
                sb.Append("Array size,Avg. iterative search time (ms),Max. iterative search time(ms),Min. iterative search time (ms)\n");
                for (int c = 0; c < numStatistics; c++)
                {
                    sb.Append($"{(c + 1) * _arrayGrowthConst},{statsIter[c][0]},{statsIter[c][1]},{statsIter[c][2]}\n");
                }
                using (Stream fs = File.Open(filePath, FileMode.Create))
                using (StreamWriter fsr = new StreamWriter(fs))
                {
                    try
                    {
                        await fsr.WriteAsync(sb.ToString());
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            });
        }

        private void cmdBenchmark2_Click(object sender, EventArgs e)
        {
            var progressMonitor = new Progress<ProgressData>(d => ReportProgress(d));
            int outSize = 0;
            if (!IO.ParseInt(txtInput, ref outSize))
            {
                IO.SetWarningText(lblWarning, "Invalid value entered!");
                return;
            }

            RunAdditiveSearchBenchmarkAsync(progressMonitor, outSize);
        }
    }
}
