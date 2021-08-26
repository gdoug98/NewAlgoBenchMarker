using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class SortAlgorithms
    {
        // private static int stackNum = 1;

        public static int[] MergeSort(int[] items)
        {
            if (items.Length > 1)
            {
                int[] left, right;
                split(items, out left, out right);
                left = MergeSort(left);
                right = MergeSort(right);
                items = merge(left, right);
            }
            return items;
        }

        #region Integer Sort Methods
        public static async Task<TaskSummary<int[]>> MergeSortAsync(int[] items, IProgress<ProgressData> reporter = null)
        {
            var summary = new TaskSummary<int[]>();
            ProgressData report = new ProgressData();
            return await Task.Run(() =>
            {
                if (reporter == null)
                {
                    if (items.Length > 1)
                    {
                        int[] left, right;
                        split(items, out left, out right);
                        left = MergeSort(left);
                        right = MergeSort(right);
                        items = merge(left, right);
                    }
                }
                else
                {
                    report.ActionCompleted = "Beginning merge sort...";
                    reporter.Report(report);
                    if (items.Length > 1)
                    {
                        int[] left, right;
                        split(items, out left, out right);
                        left = MergeSort(left);
                        right = MergeSort(right);
                        items = merge(left, right);
                    }

                    report.ActionCompleted = "Merge sort complete.";
                    reporter.Report(report);
                }
                summary.Data = items;
                // summary.UpdateTimer();
                return summary;
            });
        }

        private static int[] merge(int[] arr1, int[] arr2)
        {
            var ret = new int[arr1.Length + arr2.Length];
            int count1 = 0, count2 = 0;
            for (int i = 0; i < ret.Length; i++)
            {
                if (count1 < arr1.Length && count2 < arr2.Length)
                {
                    if (arr1[count1] > arr2[count2])
                    {
                        ret[i] = arr1[count1];
                        count1++;
                    }
                    else
                    {
                        ret[i] = arr2[count2];
                        count2++;
                    }
                }
                else if (count1 < arr1.Length)
                {
                    ret[i] = arr1[count1];
                    count1++;
                }
                else
                {
                    ret[i] = arr2[count2];
                    count2++;
                }
            }

            return ret;
        }

        private static void split(int[] source, out int[] left, out int[] right)
        {
            left = source.Take((source.Length/2)).ToArray();
            right = source.Skip((source.Length / 2)).ToArray();
        }

        public static int[] HeapSort(int[] items)
        {
            // build heap
            for (int i = (items.Length / 2) - 1; i >= 0; i--)
            {
                items = heapify(items, i, items.Length-1);
            }

            // sort binary heap
            for(int j = items.Length-1; j >= 0; j--)
            {
                Common.Swap(ref items[j], ref items[0]);
                items = heapify(items, 0, j);
            }

            return items;
        }

        public static async Task<TaskSummary<int[]>> HeapSortAsync2(int[] items, int low, int high)
        {
            var summary = new TaskSummary<int[]>();
            return await Task.Run(() =>
            {
                // build heap
                for (int i = (high / 2) - 1; i >= low; i--)
                {
                    items = heapify(items, i, high - 1);
                }

                // sort binary heap
                for (int j = high - 1; j >= low; j--)
                {
                    Common.Swap(ref items[j], ref items[low]);
                    items = heapify(items, low, j);
                }
                summary.Data = items;
                // summary.UpdateTimer();
                return summary;
            });
        }

        public static async Task<TaskSummary<int[]>> HeapSortAsync(int[] items)
        {
            var summary = new TaskSummary<int[]>();
            return await Task.Run(() =>
            {
                // build heap
                for (int i = (items.Length / 2) - 1; i >= 0; i--)
                {
                    items = heapify(items, i, items.Length - 1);
                }

                // sort binary heap
                for (int j = items.Length - 1; j >= 0; j--)
                {
                    Common.Swap(ref items[j], ref items[0]);
                    items = heapify(items, 0, j);
                }
                summary.Data = items;
                // summary.UpdateTimer();
                return summary;
            });
        }

        private static int[] heapify(int[] items, int root, int bound)
        {
            int left = (2 * root) + 1, right = (2 * root) + 2, largest = root;
            if (left < bound && items[left] > items[largest])
            {
                largest = left;
            }
            if (right < bound && items[right] > items[largest])
            {
                largest = right;
            }

            if (largest != root)
            {
                Common.Swap(ref items[root], ref items[largest]);
                items = heapify(items, largest, bound);
            }

            return items;
        }

        public static async Task<TaskSummary<int[]>> QuickSortAsnyc(int[] items, int low, int high)
        {
            // stackNum = 1;
            TaskSummary<int[]> ret = new TaskSummary<int[]>();
            return await Task.Run(() => 
            {
                //var pData = new ProgressData { ActionCompleted = "Started sort." };
                //reporter.Report(pData);
                // stackNum++;
                if (low < high)
                {
                    int p = partition(items, low, high);
                    items = QuickSort(items, p, high);
                    items = QuickSort(items, low, p - 1);
                }
                ret.Data = items;
                // ret.UpdateTimer();
                // pData.ActionCompleted = $"Final stack recursion value: {stackNum}";
                // reporter.Report(pData);
                return ret;
            });
        }

        public static async Task<TaskSummary<int[]>> QuickSortAsnyc2(int[] items, int low, int high)
        {
            TaskSummary<int[]> ret = new TaskSummary<int[]>();
            return await Task.Run(() =>
            {
                if (low < high)
                {
                    if (high - low <= 5)
                    {
                        // bubble sort optimisation
                        bubble(items, low, high);
                    }
                    else
                    {
                        int p = partition(items, low, high);
                        items = QuickSort2(items, p, high);
                        items = QuickSort2(items, low, p - 1);
                    }
                }

                ret.Data = items;
                // ret.UpdateTimer();
                return ret;
            });
        }

        // Quick sort
        public static int[] QuickSort(int[] items, int low, int high)
        {
            // stackNum++;
            if (low < high)
            {
                int p = partition(items, low, high);
                items = QuickSort(items, p, high);
                items = QuickSort(items, low, p - 1);
            }
            return items;
        }

        public static int[] QuickSort2(int[] items, int low, int high)
        {
            // stackNum++;

            if (low < high)
            {
                if (high - low <= 5)
                {
                    // bubble sort optimisation
                    bubble(items, low, high);
                }
                else
                {
                    int p = partition(items, low, high);
                    items = QuickSort2(items, p, high);
                    items = QuickSort2(items, low, p - 1);
                }
            }
            return items;
        }

        private static int partition(int[] items, int low, int high)
        {
            int pivot = items[(low + high) / 2];

            while (low < high)
            {
                while (items[low] < pivot)
                {
                    low++;
                }
                while (items[high] > pivot)
                {
                    high--;
                }
                if (low <= high)
                {
                    Common.Swap(ref items[low], ref items[high]);
                    low++;
                    high--;
                }

            }
            return low;
        }

        // for use with arrays of size < 5. Using as possible optimisation with quicksort to reduce recursion
        private static void bubble(int[] items, int low, int high)
        {
            bool sorted = false, swapped = false;
            while (!sorted)
            {
                swapped = false;
                for (int x = low; x < high; x++)
                {
                    if (items[x] > items[x + 1])
                    {
                        Common.Swap(ref items[x], ref items[x + 1]);
                        swapped = true;
                    }
                }
                sorted = !swapped;
            }
        }
        #endregion

        #region Generic Sort methods
        public static T[] MergeSort<T>(T[] items) where T : IComparable<T>
        {
            if (items.Length > 1)
            {
                T[] left, right;
                split(items, out left, out right);
                left = MergeSort(left);
                right = MergeSort(right);
                items = merge(left, right);
            }
            return items;
        }

        public static async Task<TaskSummary<T[]>> MergeSortAsync<T>(T[] items, IProgress<ProgressData> reporter = null) where T : IComparable<T>
        {
            var summary = new TaskSummary<T[]>();
            ProgressData report = new ProgressData();
            return await Task.Run(() =>
            {
                if (reporter == null)
                {
                    if (items.Length > 1)
                    {
                        T[] left, right;
                        split(items, out left, out right);
                        left = MergeSort(left);
                        right = MergeSort(right);
                        items = merge(left, right);
                    }
                }
                else
                {
                    report.ActionCompleted = "Beginning merge sort...";
                    reporter.Report(report);
                    if (items.Length > 1)
                    {
                        T[] left, right;
                        split(items, out left, out right);
                        left = MergeSort(left);
                        right = MergeSort(right);
                        items = merge(left, right);
                    }

                    report.ActionCompleted = "Merge sort complete.";
                    reporter.Report(report);
                }
                summary.Data = items;
                // summary.UpdateTimer();
                return summary;
            });
        }

        private static T[] merge<T>(T[] arr1, T[] arr2) where T : IComparable<T>
        {
            var ret = new T[arr1.Length + arr2.Length];
            int count1 = 0, count2 = 0;
            for (int i = 0; i < ret.Length; i++)
            {
                if (count1 < arr1.Length && count2 < arr2.Length)
                {
                    if (arr1[count1].CompareTo(arr2[count2]) > 0)
                    {
                        ret[i] = arr1[count1];
                        count1++;
                    }
                    else
                    {
                        ret[i] = arr2[count2];
                        count2++;
                    }
                }
                else if (count1 < arr1.Length)
                {
                    ret[i] = arr1[count1];
                    count1++;
                }
                else
                {
                    ret[i] = arr2[count2];
                    count2++;
                }
            }

            return ret;
        }

        private static void split<T>(T[] source, out T[] left, out T[] right)
        {
            left = source.Take((source.Length / 2)).ToArray();
            right = source.Skip((source.Length / 2)).ToArray();
        }

        public static T[] HeapSort<T>(T[] items) where T : IComparable<T>
        {
            // build heap
            for (int i = (items.Length / 2) - 1; i >= 0; i--)
            {
                items = heapify(items, i, items.Length - 1);
            }

            // sort binary heap
            for (int j = items.Length - 1; j >= 0; j--)
            {
                Common.Swap(ref items[j], ref items[0]);
                items = heapify(items, 0, j);
            }

            return items;
        }

        public static async Task<TaskSummary<T[]>> HeapSortAsync2<T>(T[] items, int low, int high) where T : IComparable<T>
        {
            var summary = new TaskSummary<T[]>();
            return await Task.Run(() =>
            {
                // build heap
                for (int i = (high / 2) - 1; i >= low; i--)
                {
                    items = heapify(items, i, high - 1);
                }

                // SortG binary heap
                for (int j = high - 1; j >= low; j--)
                {
                    Common.Swap(ref items[j], ref items[low]);
                    items = heapify(items, low, j);
                }
                summary.Data = items;
                // summary.UpdateTimer();
                return summary;
            });
        }

        public static async Task<TaskSummary<T[]>> HeapSortAsync<T>(T[] items) where T : IComparable<T>
        {
            var summary = new TaskSummary<T[]>();
            return await Task.Run(() =>
            {
                // build heap
                for (int i = (items.Length / 2) - 1; i >= 0; i--)
                {
                    items = heapify(items, i, items.Length - 1);
                }

                // sort binary heap
                for (int j = items.Length - 1; j >= 0; j--)
                {
                    Common.Swap(ref items[j], ref items[0]);
                    items = heapify(items, 0, j);
                }
                summary.Data = items;
                // summary.UpdateTimer();
                return summary;
            });
        }

        private static T[] heapify<T>(T[] items, int root, int bound) where T : IComparable<T>
        {
            int left = (2 * root) + 1, right = (2 * root) + 2, largest = root;
            if (left < bound && items[left].CompareTo(items[largest]) > 0)
            {
                largest = left;
            }
            if (right < bound && items[right].CompareTo(items[largest]) > 0)
            {
                largest = right;
            }

            if (largest != root)
            {
                Common.Swap(ref items[root], ref items[largest]);
                items = heapify(items, largest, bound);
            }

            return items;
        }

        public static async Task<TaskSummary<T[]>> QuickSortAsnyc<T>(T[] items, int low, int high) where T : IComparable<T>
        {
            // stackNum = 1;
            TaskSummary<T[]> ret = new TaskSummary<T[]>();
            return await Task.Run(() =>
            {
                //var pData = new ProgressData { ActionCompleted = "Started sort." };
                //reporter.Report(pData);
                // stackNum++;
                if (low < high)
                {
                    int p = partition(items, low, high);
                    items = QuickSort(items, p, high);
                    items = QuickSort(items, low, p - 1);
                }
                ret.Data = items;
                // ret.UpdateTimer();
                // pData.ActionCompleted = $"Final stack recursion value: {stackNum}";
                // reporter.Report(pData);
                return ret;
            });
        }

        public static async Task<TaskSummary<T[]>> QuickSortAsnyc2<T>(T[] items, int low, int high) where T : IComparable<T>
        {
            TaskSummary<T[]> ret = new TaskSummary<T[]>();
            return await Task.Run(() =>
            {
                if (low < high)
                {
                    if (high - low <= 5)
                    {
                        // bubble sort optimisation
                        bubble(items, low, high);
                    }
                    else
                    {
                        int p = partition(items, low, high);
                        items = QuickSort2(items, p, high);
                        items = QuickSort2(items, low, p - 1);
                    }
                }

                ret.Data = items;
                // ret.UpdateTimer();
                return ret;
            });
        }

        // Quick sort
        public static T[] QuickSort<T>(T[] items, int low, int high) where T : IComparable<T>
        {
            // stackNum++;
            if (low < high)
            {
                int p = partition(items, low, high);
                items = QuickSort(items, p, high);
                items = QuickSort(items, low, p - 1);
            }
            return items;
        }

        public static T[] QuickSort2<T>(T[] items, int low, int high) where T : IComparable<T>
        {
            // stackNum++;

            if (low < high)
            {
                if (high - low <= 5)
                {
                    // bubble sort optimisation
                    bubble(items, low, high);
                }
                else
                {
                    int p = partition2(items, low, high);
                    items = QuickSort2(items, p, high);
                    items = QuickSort2(items, low, p - 1);
                }
            }
            return items;
        }

        private static int partition<T>(T[] items, int low, int high) where T : IComparable<T>
        {
            T pivot = items[high];
            int i = low;
            for(int j = low; j < high; j++)
            {
                if(items[j].CompareTo(pivot) < 0)
                {
                    Common.Swap(ref items[j], ref items[i]);
                    i++;
                }                
            }
            Common.Swap(ref items[i], ref items[high]);
            return i;
        }

        private static int partition2<T>(T[] items, int low, int high) where T : IComparable<T>
        {
            T pivot = items[(low + high) / 2];

            while (low < high)
            {
                while (items[low].CompareTo(pivot) < 0)
                {
                    low++;
                }
                while (items[high].CompareTo(pivot) > 0)
                {
                    high--;
                }
                if (low <= high)
                {
                    Common.Swap(ref items[low], ref items[high]);
                    low++;
                    high--;
                }

            }
            return low;
        }

        // for use with arrays of size < 5. Using as possible optimisation with quicksort to reduce recursion
        private static void bubble<T>(T[] items, int low, int high) where T : IComparable<T>
        {
            bool sorted = false, swapped = false;
            while (!sorted)
            {
                swapped = false;
                for (int x = low; x < high; x++)
                {
                    if (items[x].CompareTo(items[x + 1]) > 0)
                    {
                        Common.Swap(ref items[x], ref items[x + 1]);
                        swapped = true;
                    }
                }
                sorted = !swapped;
            }
        }
        #endregion
    }
}
