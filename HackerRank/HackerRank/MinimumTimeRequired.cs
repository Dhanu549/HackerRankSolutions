using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public static class MinimumTimeRequired
    {
        public static void Execute()
        {
            string[] nGoal = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nGoal[0]);

            long goal = Convert.ToInt64(nGoal[1]);

            long[] machines = Array.ConvertAll(Console.ReadLine().Split(' '), machinesTemp => Convert.ToInt64(machinesTemp))
            ;
            long ans = minTime(machines, goal);

            Console.WriteLine(ans);
        }

        static long minTime(long[] machines, long goal)
        {
            //decimal m = 1, s = 0;
            //foreach(long l in machines)
            //    m *= l;
            //foreach (long l in machines)
            //    s += m / l;

            //decimal result = (m / s) * goal;
            //decimal test = (m * goal) % s;
            //return Convert.ToInt64(Math.Ceiling(result));

            Array.Sort(machines);

            long maximumPossibleTime = machines.Last() * goal / machines.Length;

            long minimumPossibleTime = machines.First() * goal / machines.Length;

            long numberOfDays = BinarySearchForOptimalTime(machines, goal, minimumPossibleTime, maximumPossibleTime);

            return numberOfDays;
        }

        static long BinarySearchForOptimalTime(long[] machines, long goal, long min, long max)
        {
            long mid = 0, noOfItems;

            while (min < max)
            {
                mid = min + (max - min) / 2;
                noOfItems = CalculateItemsForGivenDays(machines, mid);

                if (noOfItems < goal)
                    min = mid + 1;
                else
                    max = mid;
            }
            return max;
        }

        static long CalculateItemsForGivenDays(long[] machines, long days)
        {
            long items = 0;
            for (int i = 0; i < machines.Length; i++)
                items += (days / machines[i]);
            return items;
        }
    }
}
