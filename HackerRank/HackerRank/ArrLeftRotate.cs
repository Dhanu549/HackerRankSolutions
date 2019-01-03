using System;

namespace HackerRank
{
    public static class ArrLeftRotate
    {
        public static void Execute()
        {
            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            int[] result = rotLeft(a, d);

            Console.WriteLine(string.Join(" ", result));
        }

        private static int[] rotLeft(int[] a, int d)
        {
            int l = a.Length;
            int[] result = new int[l];
            for (int i = 0; i < l; i++)
            {
                result[i] = a[(i + d) % l];
            }
            return result;
        }
    }
}
