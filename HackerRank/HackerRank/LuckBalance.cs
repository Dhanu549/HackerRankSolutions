using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public static class LuckBalance
    {
        public static void Execute()
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[][] contests = new int[n][];

            for (int i = 0; i < n; i++)
            {
                contests[i] = Array.ConvertAll(Console.ReadLine().Split(' '), contestsTemp => Convert.ToInt32(contestsTemp));
            }

            int result = luckBalance(k, contests);

            Console.WriteLine(result);
        }

        static int luckBalance(int k, int[][] contests)
        {
            int luckBal = 0;
            int impContestCount = 0;
            SortedDictionary<int, int> important = new SortedDictionary<int, int>();
            foreach(var contest in contests)
            {
                if(contest[1] == 1)
                {
                    impContestCount++;
                    if (important.ContainsKey(contest[0]))
                        important[contest[0]]++;
                    else
                        important.Add(contest[0], 1);
                }
                else
                {
                    luckBal += contest[0];
                }
            }
            int loose = impContestCount - k;
            foreach (var contest in important)
            {
                if (loose >= contest.Value)
                {
                    luckBal -= contest.Key * contest.Value;
                    loose -= contest.Value;
                }
                else if (loose > 0)
                {
                    luckBal += contest.Key * (contest.Value - loose);
                    loose = 0;
                }
                else
                    luckBal += contest.Key * contest.Value;               
            }
            return luckBal;
        }
    }
}
