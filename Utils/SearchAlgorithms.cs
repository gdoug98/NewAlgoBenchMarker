using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// Class containing 2 versions of the binary search algorithm for benchmarking.
    /// </summary>
    public class SearchAlgorithms
    {
        /// <summary>
        /// Iterative version of the binary search algorithm.
        /// </summary>
        /// <param name="items">array of integers to search through</param>
        /// <param name="value">integer value to search for</param>
        /// <returns>index of the value in the array, if it's there. -1 if it can't be found.</returns>
        public static int IterativeBinarySearch(int[] items, int value)
        {
            int midInx, hiInx, loInx, retVal;
            hiInx = items.Length - 1;
            loInx = 0;
            midInx = ((hiInx + loInx) / 2);
            retVal = -1;// if the value isn't found within the array, this default value is returned
            while (hiInx > loInx)
            {
                if (items[midInx] == value)
                {
                    return midInx;
                   
                }
                else if (items[midInx] < value)
                {
                    loInx = midInx + 1;
                }
                else
                {
                    hiInx = midInx - 1;
                }
                midInx = ((hiInx + loInx) / 2);
            }
            return retVal;
        }

        public static async Task<TaskSummary<int>> IterativeBinarySearchAsync(int[] items, int value, int hi, int lo)
        {
            var ret = new TaskSummary<int>();
            return await Task.Run(() =>
            {
                int midInx, hiInx, loInx, retVal;
                hiInx = hi;
                loInx = lo;
                midInx = ((hiInx + loInx) / 2);
                retVal = -1; // if the value isn't found within the array, this default value is returned
                while (hiInx > loInx)
                {
                    if (items[midInx] == value)
                    {
                        ret.Data = midInx;
                        // ret.UpdateTimer();
                        return ret;
                    }
                    else if (items[midInx] < value)
                    {
                        loInx = midInx + 1;
                    }
                    else
                    {
                        hiInx = midInx - 1;
                    }

                    midInx = ((hiInx + loInx) / 2);
                }
                ret.Data = retVal;
                // ret.UpdateTimer();
                return ret;
            });

        }

        /// <summary>
        /// Recursive version of binary search. Steps through numerous cases, returns -1 if
        /// value requested can't be found in array.
        /// </summary>
        /// <param name="items">Array of items to be searched</param>
        /// <param name="value">Value to find within array</param>
        /// <param name="hi">higher bound</param>
        /// <param name="lo">lower bound</param>
        /// <returns></returns>
        public static int RecursiveBinarySearch(int[] items, int value, int hi, int lo)
        {
            int mid, retVal;
            mid = ((hi + lo) / 2);
            retVal = -1;
            if (lo >= hi)
            {
                return -1;
            }
            if (items[mid] == value)
            {
                retVal = mid;
            }
            else if (items[mid] > value)
            {
                retVal = RecursiveBinarySearch(items, value, (mid - 1), lo);
            }
            else if (items[mid] < value)
            {
                retVal = RecursiveBinarySearch(items, value, hi, (mid + 1));
            }
            return retVal;
        }

        /// <summary>
        /// Asynchronous version of recursive binary search.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="value"></param>
        /// <param name="hi"></param>
        /// <param name="lo"></param>
        /// <returns></returns>
        public static async Task<TaskSummary<int>> RecursiveBinarySearchAsync(int[] items, int value, int hi, int lo)
        {
            var ret = new TaskSummary<int>();

            return await Task.Run(() =>
            {
                int retVal = 0;
                int mid = ((hi + lo) / 2);
                if (lo >= hi)
                {
                    retVal =  -1;
                }

                else if (items[mid] == value)
                {
                    retVal = mid;
                }
                else if (items[mid] > value)
                {
                    retVal = RecursiveBinarySearch(items, value, (mid - 1), lo);
                }
                else if (items[mid] < value)
                {
                    retVal = RecursiveBinarySearch(items, value, hi, (mid + 1));
                }
                ret.Data = retVal;
                // ret.UpdateTimer();
                return ret;                
            });
        }
    }
}
