using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static class NotInRange
    {
        public static void Execute()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            long sum = 0;
            SortedDictionary<int, int> d = new SortedDictionary<int, int>();
            for (int i = 0; i < N; i++)
            {
                int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
                if (d.ContainsKey(a[0]) && d[a[0]] < a[1])
                {
                    d[a[0]] = a[1];
                }
                else
                {
                    d.Add(a[0], a[1]);
                }
            }
            if(d.Count >=1)
            {
                int start = d.First().Key;
                sum = start * (start - 1) / 2;
                int end = d.First().Value;
                d.Remove(start);

                foreach (var item in d)
                {
                    if (item.Key <= end + 1 && item.Value >= end + 1)
                    {
                        end = item.Value;
                    }
                    else if (item.Key > end)
                    {
                        sum += ((long)item.Key * (item.Key - 1)) / 2 - ((long)end * (end + 1)) / 2;
                        end = item.Value;
                    }
                }
                if (end < 1000000)
                    sum += ((long)1000000 * 1000001)/2 - ((long)end * (end + 1)) / 2;
            }            

            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
