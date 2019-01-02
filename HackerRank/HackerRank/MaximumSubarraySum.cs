using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public static class MaximumSubarraySum
    {
        public static void Execute()
        {
            long q = Convert.ToInt32(Console.ReadLine());

            for (long qItr = 0; qItr < q; qItr++)
            {
                string[] nm = Console.ReadLine().Split(' ');

                long n = Convert.ToInt32(nm[0]);

                long m = Convert.ToInt64(nm[1]);

                long[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt64(aTemp))
                ;
                long result = maximumSum(a, m);

                Console.WriteLine(result);
            }
        }

        static long maximumSum(long[] a, long m)
        {
            long[] modSum = new long[a.Length];
            SortedSet<long> ts = new SortedSet<long>();
            long total = 0;
            long result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                total = (total + a[i]) % m;
                modSum[i] = total;
                if (total > result)
                {
                    result = total;
                }
            }
            for (int i = 0; i < modSum.Length; i++)
            {
                ts.Add(modSum[i]);
                long least = ts.GetViewBetween(modSum[i] + 1, m + modSum[i] - result).FirstOrDefault();

                if ((m + modSum[i] - least) % m > result)
                    result = (m + modSum[i] - least) % m;                
            }
            return result;
        }
    }
}
