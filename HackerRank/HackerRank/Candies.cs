using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public class Candies
    {
        public static void Execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int arrItem = Convert.ToInt32(Console.ReadLine());
                arr[i] = arrItem;
            }

            long result = candies(n, arr);

            Console.WriteLine(result);
        }

        private static long candies(int n, int[] arr)
        {
            //long sum = 1;
            //int prev = 1;
            //for (int i = 1; i < n; i++)
            //{
            //    if (arr[i] > arr[i - 1])
            //        prev++;
            //    else if (i < n - 1 && arr[i] > arr[i + 1])
            //        prev = 2;
            //    else
            //        prev = 1;
            //    sum += prev;
            //}
            //return sum;

            long[] vals = new long[n];
            vals[0] = 1;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] > arr[i - 1])
                    vals[i] = vals[i - 1] + 1;
                else
                    vals[i] = 1;
            }

            for(int i = n-2; i >= 0; i--)
            {
                if (arr[i] > arr[i + 1] && vals[i] <= vals[i + 1])
                    vals[i] = vals[i + 1] + 1;
            }

            return vals.Sum();
        }
    }
}
