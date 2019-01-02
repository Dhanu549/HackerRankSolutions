using System;

namespace HackerRank
{
    public static class CommonChild
    {
        public static void Execute()
        {
            string s1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            int result = commonChild(s1, s2);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        static int commonChild(string s1, string s2)
        {
            int[,] arr = new int[s1.Length + 1,s2.Length + 1];

            for (int i = 0; i < s1.Length; i++)
                for (int j = 0; j < s2.Length; j++)
                    arr[i + 1,j + 1] = (s1[i] == s2[j]) ? arr[i,j] + 1 : Math.Max(arr[i,j + 1], arr[i + 1,j]);

            return arr[s2.Length,s1.Length];
        }
    }
}
