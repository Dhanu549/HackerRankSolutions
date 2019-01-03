using System;

namespace HackerRank
{
    public static class CountingValleys
    {
        public static void Execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            string s = Console.ReadLine();

            int result = countingValleys(n, s);

            Console.WriteLine(result);
        }

        private static int countingValleys(int n, string s)
        {
            int result = 0, l = 0;
            foreach (char c in s)
            {
                if (c == 'U')
                {
                    l++;
                    if (l == 0)
                        result++;
                }
                else if (c == 'D')
                {
                    l--;
                }
            }
            return result;
        }
    }
}
