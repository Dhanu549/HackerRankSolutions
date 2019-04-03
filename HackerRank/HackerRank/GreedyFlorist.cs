using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public static class GreedyFlorist
    {
        public static void Execute()
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
            ;
            int minimumCost = getMinimumCost(k, c);

            Console.WriteLine(minimumCost);
        }

        static int getMinimumCost(int k, int[] c)
        {
            int minCost = 0, extraCost = 0, count = 0, index = 0;
            int[] costs = new int[c.Length];

            //You can use quick sort as well for sorting in O(n logn) instead of the following approach
            SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
            foreach(int i in c)
            {
                if (dict.ContainsKey(i))
                    dict[i]++;
                else
                    dict.Add(i, 1);
            }
            var d = dict.Reverse();
            foreach(var item in d)
            {
                for (int i = 1; i <= item.Value; i++)
                    costs[index++] = item.Key;
            }
            //costs is sorted in reverse order

            for (int i = 0; i < costs.Length; i++)
            {
                if (count % k == 0)
                    extraCost++;
                minCost += extraCost * costs[i];
                count++;
            }

            return minCost;
        }
    }
}
