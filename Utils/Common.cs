using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Utils
{
   public class Common
    {
        /// <summary>
        /// Returns a random positive 32-bit integer between the lower and upper boundary values, inclusive.
        /// Since this method uses a random number generator from the System.Security.Cryptography
        /// namespace, it's cryptographically secure.
        /// </summary>
        /// <param name="lower">lower bound for the value</param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public static int GetRandomValue(int lower, int upper)
        {
            var rand = RandomNumberGenerator.Create();
            // store bytes retrieved from RNG
            var rawBytes = new byte[4];
            rand.GetBytes(rawBytes);

            // Convert byte array to 32-bit integer, return value;
            return Math.Abs(lower+BitConverter.ToInt32(rawBytes, 0)) % (upper+1);
        }

        public static long CalculateAverage(long sum, long numVals)
        {
            return sum / numVals;
        }

        /// <summary>
        /// Randomly reogranises values in an array.
        /// </summary>
        /// <param name="source">Array to be randomised</param>
        /// <returns></returns>
        public static int[] ShuffleArray(int[] source)
        {
            var bound = source.Length - 1;
            for (int c = 0; c < source.Length; c++)
            {
                var randInx = GetRandomValue(0, bound);
                Swap(ref source[randInx], ref source[bound]);
                // decrement bound, increase size of "shuffled" region of array
                bound--;
            }

            return source;
        }

        public static async Task<int[]> ShuffleArrayAsync(int[] source, IProgress<ProgressData> progressReporter, ProgressData progressReport = null)
        {
            ProgressData report = progressReport ?? new ProgressData();
            return await Task.Run(() =>
                {
                    report.ActionCompleted = "Array shuffling started...";
                    progressReporter.Report(report);
                    var bound = source.Length - 1;
                    report.ActionCompleted = string.Empty;
                    for (int c = 0; c < source.Length; c++)
                    {
                        var randInx = GetRandomValue(0, bound);
                        Swap(ref source[randInx], ref source[bound]);
                        // decrement bound, increase size of "shuffled" region of array
                        bound--;
                        report.PercentComplete = (c * 100) / source.Length;
                        progressReporter.Report(report);
                    }

                    report.ActionCompleted = $"Shuffling complete. Time taken: {report.TimeElapsed.Milliseconds}ms";
                    report.PercentComplete = 100;
                    progressReporter.Report(report);
                    return source;
                }
            );
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        public static int Sum(int start, int end)
        {
            int ret = 0;
            for (int x = start; x < end; x++)
            {
                ret += x;
            }
            return ret;
        }

        public static long Sum(params long[] longs)
        {
            long ret = 0;
            foreach(long l in longs)
            {
                ret += l;
            }
            return ret;
        }
    }
}
