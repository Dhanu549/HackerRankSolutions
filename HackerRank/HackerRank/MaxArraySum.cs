using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class MaxArraySum
    {
        public static void Execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            int res = maxSubsetSum(arr);

            Console.WriteLine(res);
        }

        private static int maxSubsetSum(int[] arr)
        {
            int incl = arr[0];
            int excl = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                int exclNew = incl > excl ? incl : excl;
                incl = excl + arr[i];
                excl = exclNew;
            }

            return incl > excl ? incl : excl;
        }
    }
}
