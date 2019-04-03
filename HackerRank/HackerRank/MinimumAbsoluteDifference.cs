using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public static class MinimumAbsoluteDifference
    {
        public static void Execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            int result = minimumAbsoluteDifference(arr);

            Console.WriteLine(result);
        }

        static int minimumAbsoluteDifference(int[] arr)
        {
            int min = int.MaxValue;
            SortedDictionary<int, int> d= new SortedDictionary<int, int>();
            for(int i=0;i<arr.Length;i++)
            {
                if (d.ContainsKey(arr[i]))
                    d[arr[i]]++;
                else
                    d.Add(arr[i], 1);
            }

            if (d.Any(x => x.Value > 1))
                return 0;

            int previous = d.First().Key;
            d.Remove(previous);

            foreach(var item in d)
            {
                if (Math.Abs(item.Key - previous) < min)
                    min = Math.Abs(item.Key - previous);
                previous = item.Key;
            }

            return min;
        }
    }
}
