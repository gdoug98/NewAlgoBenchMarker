using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class ArrayGenerator
    {
        private const int DEFAULT_ARRAY_SIZE = 500000;
        private int _arraySize;
        // values to limit randomly generated values.
        private int _hiBound;
        private int _loBound;

        public int arraySize => _arraySize;
        public int highBound => _hiBound;
        public int lowBound => _loBound;

        public ArrayGenerator()
        {
            _arraySize = DEFAULT_ARRAY_SIZE;
            _hiBound = Int32.MaxValue;
            _loBound = 0;
        }

        public ArrayGenerator(int arraySize, int lo, int hi)
        {
            _arraySize = arraySize;
            _hiBound = hi;
            _loBound = lo;
        }

        public int[] GenerateArray()
        {
            var ret = new int[_arraySize];
            var RNG = System.Security.Cryptography.RandomNumberGenerator.Create();
            var bytes = new byte[4];// allows the storage of a single random 32-bit integer.
            // this will probably take a while...
            for (int c = 0; c < _arraySize; c++)
            {
                // fill byte array with random bytes.
                RNG.GetBytes(bytes);
                // Convert byte array to 32-bit integer, then constrict to bound.
                ret[c] = Math.Abs(_loBound+BitConverter.ToInt32(bytes, 0))%_hiBound;
                                                        
            }
            return ret;
        }

        /// <summary>
        /// Generates an array - for use with multithreading.
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="progressReport"></param>
        /// <returns></returns>
        public async Task<int[]> GenerateArrayAsync(IProgress<ProgressData> progress, ProgressData progressReport = null)
        {
            Task<int[]> retVal = null;
            
            // Object containing information on task progress.
            var report = progressReport ?? new ProgressData();
            
            // Put array generator into seperate worker thread
            var task = await Task.Run(async() =>
            {
                // report on task start
                report.ActionCompleted = "Generating array...";
                progress.Report(report);

                var ret = new int[_arraySize];
                var RNG = System.Security.Cryptography.RandomNumberGenerator.Create();
                //var bytes = new byte[4]; // allows the storage of a single random 32-bit integer.

                report.ActionCompleted = string.Empty;

                // this will probably take a while...
                for (int c = 0; c < _arraySize; c++)
                {
                    //asynchronously generate random values
                    var value = await GetRandomValueAsync(RNG);
                    ret[c] = value;

                    // report progress on RNG
                    report.PercentComplete = (float)(c * 100) / (_arraySize - 1);
                    // report.TicksElapsed;
                    progress.Report(report);
                }
                // report on task completion
                report.PercentComplete = 100;
                report.ActionCompleted = $"Array generated. Time taken: {report.TimeElapsed.TotalMilliseconds}ms";
                progress.Report(report);
                return ret;
            });

            return task;

        }

        public async Task<int[]> GetArrayAsync(IProgress<ProgressData> reporter)
        {
            var RNG = System.Security.Cryptography.RandomNumberGenerator.Create();
            var ret = await Task.Run(async () => { return await GetRandomValuesAsync(RNG, reporter); });
            ProgressData report = new ProgressData { PercentComplete = 100 };
            report.ActionCompleted = $"Array generated in {report.TimeElapsed.TotalMilliseconds}ms";
            reporter.Report(report);
            return ret;
        }

        private Task<int[]> GetRandomValuesAsync(System.Security.Cryptography.RandomNumberGenerator rng, IProgress<ProgressData> reporter)
        {
            byte[] rawBytes = new byte[_arraySize * 4];
            rng.GetBytes(rawBytes);
            var report = new ProgressData();
            return Task.Run(() =>
            {
                int[] ret = new int[_arraySize];
                for(int j = 0; j < _arraySize; j++)
                {
                    ret[j] = Math.Abs(_loBound + (BitConverter.ToInt32(rawBytes, j * 4) % (_hiBound - _loBound)));

                    // report progress on RNG
                    report.PercentComplete = (float)(j * 100) / (_arraySize - 1);
                    // report.TicksElapsed;
                    reporter.Report(report);
                }
                return ret;
            });

        }

        private Task<int> GetRandomValueAsync(System.Security.Cryptography.RandomNumberGenerator rng)
        {
            return Task.Run(() =>
            {
                var bytes = new byte[4];
                // fill byte array with random bytes.
                rng.GetBytes(bytes);
                // Convert byte array to 32-bit integer, then constrict to bound.
                return Math.Abs(_loBound + (BitConverter.ToInt32(bytes, 0) % (_hiBound - _loBound)));
            });
            
        }
    }
}
