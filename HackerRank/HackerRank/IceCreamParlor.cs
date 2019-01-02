using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public static class IceCreamParlor
    {
        public static void Execute()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int money = Convert.ToInt32(Console.ReadLine());

                int n = Convert.ToInt32(Console.ReadLine());

                int[] cost = Array.ConvertAll(Console.ReadLine().Split(' '), costTemp => Convert.ToInt32(costTemp));
                whatFlavors(cost, money);
            }
        }

        static void whatFlavors(int[] cost, int money)
        {
            Dictionary<int, List<int>> d = new Dictionary<int, List<int>>();
            for (int i = 0; i < cost.Length; i++)
                if (!d.ContainsKey(cost[i]))
                    d.Add(cost[i], new List<int>() { i });
                else
                    d[cost[i]].Add(i);

            for (int i = 0; i < cost.Length - 1; i++)
            {
                if(d.ContainsKey(money-cost[i]))
                {
                    var res = d[money - cost[i]].Where(x => x > i);
                    if(res.Count()>0)
                    {
                        Console.WriteLine($"{i + 1} {res.First() + 1}");
                        return;
                    }
                }
            }

            //for (int i = 0; i < cost.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < cost.Length; j++)
            //    {
            //        if (cost[j] == money - cost[i])
            //        {
            //            Console.WriteLine($"{i + 1} {j + 1}");
            //            return;
            //        }
            //    }
            //}
        }
    }
}
