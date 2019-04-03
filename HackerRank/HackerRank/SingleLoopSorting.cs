using System;

namespace HackerRank
{
    public static class SingleLoopSorting
    {
        public static void Execute()
        {
            int j = 0, prevI = 0;
            int n = Convert.ToInt32(Console.ReadLine());
            int[] x = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

            for (int i = 0; i < n - 1; i++)
            {
                j++;
                if (j < n)
                {
                    i = prevI; 
                }
                else
                {
                    j = i + 1;
                }

                if (x[i] > x[j])
                {
                    int temp = x[i];
                    x[i] = x[j];
                    x[j] = temp;
                }
                prevI = i;
            }

            for (int i = 0; i < n; i++)
                Console.WriteLine(x[i]);
        }
    }
}
