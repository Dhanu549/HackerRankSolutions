using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static class MakingAnagrams
    {
        public static void Execute()
        {
            string a = Console.ReadLine();

            string b = Console.ReadLine();

            int res = makeAnagram(a, b);

            Console.WriteLine(res);
            Console.ReadLine();
        }

        private static int makeAnagram(string a, string b)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();

            for (int i = 0; i <= 'z' - 'a'; i++)
                d.Add(i, 0);

            foreach (char c in a)
                d[c - 'a']++;
            foreach (char c in b)
                d[c - 'a']--;

            return d.Sum(x => Math.Abs(x.Value));
        }
    }
}
