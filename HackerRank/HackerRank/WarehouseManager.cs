using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public class WarehouseManager
    {
        public static void Execute()
        {
            List<long> boxes = new List<long>();
            List<long> items = new List<long>();
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int c = Convert.ToInt32(tokens_n[1]);
            
            for (int i = 0; i < c; i++)
            {
                long[] goods = Array.ConvertAll(Console.ReadLine().Split(' '), Int64.Parse);
                boxes.Add(goods[0]);
                items.Add(goods[1]);
            }

            Console.WriteLine(getmaxGoods(boxes, items, n));
        }

        public static long getmaxGoods(List<long> boxes, List<long> items, long n)
        {
            long count = 0;
            SortedDictionary<long, long> d = new SortedDictionary<long, long>();
            for(int i =0;i<boxes.Count;i++)
            {
                if (d.ContainsKey(items[i]))
                    d[items[i]] += boxes[i];
                else
                    d.Add(items[i], boxes[i]);
            }

            var dict = d.Reverse();
            foreach(var item in dict)
            {
                if(item.Value <= n)
                {
                    count += item.Key * item.Value;
                    n -= item.Value;
                }
                else
                {
                    count += item.Key * n;
                    n = 0;
                    break;
                }
            }

            return count;
        }
    }
}
