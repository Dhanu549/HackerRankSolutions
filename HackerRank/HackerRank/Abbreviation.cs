using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class Abbreviation
    {
        public static void Execute()
        {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string a = Console.ReadLine();

                string b = Console.ReadLine();

                string result = abbreviation(a, b);

                Console.WriteLine(result);
            }
        }

        private static string abbreviation(string a, string b)
        {
            //int i = 0, j = 0;
            //while (i < a.Length && j< b.Length)
            //{
            //    if (a[i].Equals(b[j]))
            //        j++;
            //    i++;
            //}

            //if (j == b.Length)
            //    return "YES";
            //return "NO";

            int m = a.Length, n = b.Length;
            bool[,] dp = new bool[n + 1, m + 1];

            dp[0, 0] = true;
            for (int i = 0; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (i == 0)
                        dp[i, j] = Char.IsLower(a[j - 1]) && dp[i, j - 1];
                    else
                    {
                        if (a[j - 1] == b[i - 1])
                            dp[i, j] = dp[i - 1, j - 1];
                        else if (Char.ToUpper(a[j - 1]) == b[i - 1])
                            dp[i, j] = dp[i - 1, j - 1] || dp[i, j - 1];
                        else if (Char.IsLower(a[j - 1]))
                            dp[i, j] = dp[i, j - 1];
                    }
                }
            }
            if (dp[n, m])
                return "YES";
            else
                return "NO";
        }
    }
}
