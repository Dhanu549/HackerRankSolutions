using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static class ArrManipulation
    {
        public static void Execute()
        {
            string[] nm = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nm[0]);

            int m = Convert.ToInt32(nm[1]);

            int[][] queries = new int[m][];

            for (int i = 0; i < m; i++)
            {
                queries[i] = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
            }

            long result = arrayManipulation(n, queries);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static long arrayManipulation(int n, int[][] queries)
        {
            long[] arr = new long[n];
            long temp = 0, max = 0;

            for (int i = 0; i < queries.Length; i++)
            {
                arr[queries[i][0] - 1] += queries[i][2];
                if (queries[i][1] < n)
                    arr[queries[i][1]] -= queries[i][2];
            }

            for (int i = 0; i < n; i++)
            {
                temp += arr[i];
                if (temp > max)
                    max = temp;
            }
            return max;

            //long[] arr = new long[n];
            //for (int i = 0; i < queries.Length; i++)
            //{
            //    for (int j = queries[i][0] - 1; j <= queries[i][1] - 1; j++)
            //    {
            //        arr[j] += queries[i][2];
            //    }
            //}

            //return arr.Max();

            //long[] arr = new long[n];
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < queries.Length; j++)
            //    {
            //        if (i >= queries[j][0] && i <= queries[j][1])
            //            arr[i] += queries[j][2];
            //    }
            //}

            //return arr.Max();

            //Dictionary<int, long> d = new Dictionary<int, long>();
            //for (int i = 1; i <= n; i++)
            //{
            //    d.Add(i, 0);
            //    for (int j = 0; j < queries.Length; j++)
            //    {
            //        if (i >= queries[j][0] && i <= queries[j][1])
            //            d[i] += queries[j][2];
            //    }
            //}
            //return d.Max(x => x.Value);

            //Dictionary<int, long> d = new Dictionary<int, long>();
            //for (int i = 1; i <= n; i++)
            //{
            //    for (int j = 0; j < queries.Length; j++)
            //    {
            //        if (i >= queries[j][0] && i <= queries[j][1])
            //        {
            //            if (d.ContainsKey(i))
            //                d[i] += queries[j][2];
            //            else
            //                d.Add(i, queries[j][2]);
            //        }
            //    }
            //}
            //return d.Max(x => x.Value);            

            //Dictionary<int, long> d = new Dictionary<int, long>();
            //for (int i = 1; i <= n; i++)
            //{
            //    d.Add(i, 0);
            //}
            //for (int i = 0; i < queries.Length; i++)
            //{
            //    for (int j = queries[i][0]; j <= queries[i][1]; j++)
            //    {
            //        d[j] += queries[i][2];
            //        //if (d.ContainsKey(j))
            //        //    d[j] += queries[i][2];
            //        //else
            //        //    d.Add(j, queries[i][2]);
            //    }
            //}

            //return d.Max(x => x.Value);
        }
    }
}
