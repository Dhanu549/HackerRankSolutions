using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public static class Pairs
    {
        public static void Execute()
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            int result = pairs(k, arr);

            Console.WriteLine(result);
        }

        static int pairs(int k, int[] arr)
        {
            int result = 0;
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                d[arr[i]] = 1;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (d.ContainsKey(arr[i] - k))
                    result++;
            }
            return result;
                    
            //int result = 0;
            //for (int i = 0; i < arr.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < arr.Length; j++)
            //    {
            //        if (k == Math.Abs(arr[i] - arr[j]))
            //        {
            //            result++;
            //        }
            //    }
            //}
            //return result;
        }
    }
}
