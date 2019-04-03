using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public static class LeadLife
    {
        public static void Execute()
        {
            int[] earnings = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
            int[] costs = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
            int e = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(maxEarning(earnings, costs, e));
        }

        public static int maxEarning(int[] earnings, int[] costs, int e)
        {
            int maxEarn = 0;
            int prevIndex = -1;
            bool haveEnergy = true;
            costs[costs.Length - 1] = 0;

            for (int i = 0; i < earnings.Length; i++)
            {
                if (!haveEnergy && earnings[i] > costs[prevIndex])
                {
                    maxEarn -= (costs[prevIndex]) * e;
                    haveEnergy = true;
                }

                if (haveEnergy)
                {
                    maxEarn += earnings[i] * e;
                    haveEnergy = false;
                }
                prevIndex = i;
            }

            return maxEarn;
        }
    }
}
