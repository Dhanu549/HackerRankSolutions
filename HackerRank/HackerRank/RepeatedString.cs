using System;

namespace HackerRank
{
    public static class RepeatedString
    {
        public static void Execute()
        {
            string s = Console.ReadLine();

            long n = Convert.ToInt64(Console.ReadLine());

            long result = repeatedString(s, n);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static long repeatedString(string s, long n)
        {
            long d = n / s.Length;
            long r = n % s.Length;
            long result = 0;
            if (d == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    if (s[i] == 'a')
                    {
                        result++;
                    }
                }
            }
            else
            {                
                long strMatches = 0;
                long tail = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == 'a')
                    {
                        strMatches++;
                        if (i < r)
                            tail++;
                    }
                }
                result = strMatches * d + tail;
            }
            return result;
        }
    }
}
