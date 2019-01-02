using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static class CountTriplets
    {
        public static void Execute()
        {
            string[] nr = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(nr[0]);

            long r = Convert.ToInt64(nr[1]);

            List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

            long ans = countTriplets(arr, r);

            Console.WriteLine(ans);
            Console.ReadLine();
        }

        private static long countTriplets(List<long> arr, long r)
        {            
            long count = 0, c = arr.Count;
            Dictionary<long, long> d = new Dictionary<long, long>();
            long[] left = new long[c];
            long[] nonRight = new long[c];
            for (int i = 0; i < c; i++)
            {
                if (arr[i] % r == 0 && d.ContainsKey(arr[i] / r))
                    left[i] = d[arr[i] / r];                
                if (d.ContainsKey(arr[i]))
                    d[arr[i]]++;
                else
                    d.Add(arr[i], 1);
                if (d.ContainsKey(arr[i] * r))
                    nonRight[i] = d[arr[i] * r];
            }
            for (int i = 1; i < c - 1; i++)
            {
                if (d.ContainsKey(arr[i] * r))
                    count += left[i] * (d[arr[i] * r] - nonRight[i]);
            }
            return count;

            //long count = 0;
            //for (int i = 0; i < arr.Count - 2; i++)
            //{
            //    for (int j = i + 1; j < arr.Count - 1; j++)
            //    {
            //        if (arr[i] * r == arr[j])
            //        {
            //            for (int k = j + 1; k < arr.Count; k++)
            //            {
            //                if (arr[j] * r == arr[k])
            //                {
            //                    count++;
            //                }
            //            }
            //        }
            //    }
            //}
            //return count;

            //long count = 0;
            //for (int i = 1; i < arr.Count - 1; i++)
            //{
            //    long m = 0, n = 0; 
            //    for (int j = 0; j < i; j++)
            //    {
            //        if (arr[j] * r == arr[i])
            //        {
            //            m++;                        
            //        }
            //    }
            //    for (int k = i + 1; k < arr.Count; k++)
            //    {
            //        if (arr[i] * r == arr[k])
            //        {
            //            n++;
            //        }
            //    }
            //    count += m * n;
            //}
            //return count;
        }
    }
}
