using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public static class MaxMin
    {
        public static void Execute()
        {
            
            int n = Convert.ToInt32(Console.ReadLine());

            int k = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int arrItem = Convert.ToInt32(Console.ReadLine());
                arr[i] = arrItem;
            }

            int result = maxMin(k, arr);

            Console.WriteLine(result);
        }

        static int maxMin(int k, int[] arr)
        {
            int[] sortedArr = new int[arr.Length];
            int index = 0, unfairness = int.MaxValue;

            //You can use quick sort as well for sorting in O(n logn) instead of the following approach
            SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
            foreach (int i in arr)
            {
                if (dict.ContainsKey(i))
                    dict[i]++;
                else
                    dict.Add(i, 1);
            }
            foreach (var item in dict)
            {
                for (int i = 1; i <= item.Value; i++)
                    sortedArr[index++] = item.Key;
            }

            for (int i = k - 1; i < sortedArr.Length; i++)
            {
                if (sortedArr[i] - sortedArr[i - k + 1] < unfairness)
                {
                    unfairness = sortedArr[i] - sortedArr[i - k + 1];
                }
            }
            
            return unfairness;
        }
    }
}
