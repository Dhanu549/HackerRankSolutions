using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static class FrequencyQueries
    {
        public static void Execute()
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> ans = freqQuery(queries);

            Console.WriteLine(String.Join("\n", ans));
        }

        static List<int> freqQuery(List<List<int>> queries)
        {
            //Dictionary<int, long> d = new Dictionary<int, long>();
            //List<int> result = new List<int>();
            //foreach(var q in queries)
            //{
            //    switch(q[0])
            //    {
            //        case 1:
            //            if (d.ContainsKey(q[1]))
            //            {
            //                d[q[1]]++;
            //            }
            //            else
            //                d.Add(q[1], 1);
            //            break;
            //        case 2:
            //            if (d.ContainsKey(q[1]) && d[q[1]] > 0)
            //                    d[q[1]]--;
            //            break;
            //        case 3:
            //            if (d.ContainsValue(q[1]))
            //                result.Add(1);
            //            else
            //                result.Add(0);
            //            break;
            //    }                
            //}
            //return result;

            Dictionary<int, long> d = new Dictionary<int, long>();
            Dictionary<long, long> f = new Dictionary<long, long>();
            List<int> result = new List<int>();
            foreach (var q in queries)
            {
                switch (q[0])
                {
                    case 1:
                        if (d.ContainsKey(q[1]))
                        {
                            if (f.ContainsKey(d[q[1]]) && f[d[q[1]]] > 0)
                            {
                                f[d[q[1]]]--;                                
                            }
                            if (f.ContainsKey(d[q[1]] + 1))
                                f[d[q[1]] + 1]++;
                            else
                                f.Add(d[q[1]] + 1, 1);
                            d[q[1]]++;
                        }
                        else
                        {
                            d.Add(q[1], 1);
                            if (!f.ContainsKey(1))
                                f.Add(1, 1);
                            else
                                f[1]++;
                        }                            
                        break;
                    case 2:
                        if (d.ContainsKey(q[1]) && d[q[1]] > 0)
                        {
                            if (f.ContainsKey(d[q[1]]) && f[d[q[1]]] > 0)
                            {
                                f[d[q[1]]]--;                                
                            }
                            if (d[q[1]] - 1 > 0 && f.ContainsKey(d[q[1]] - 1))
                                f[d[q[1]] - 1]++;
                            else if (d[q[1]] - 1 > 0)
                                f.Add(d[q[1]] - 1, 1);
                            d[q[1]]--;
                        }                            
                        break;
                    case 3:
                        if (f.ContainsKey(q[1]) && f[q[1]] > 0)
                            result.Add(1);
                        else
                            result.Add(0);
                        break;
                }
            }
            return result;
        }
    }
}
