using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    class DnaComplement
    {
        public static void Execute()
        {
            dnaComplement(Console.ReadLine());
            Console.ReadLine();
        }

        public static string dnaComplement(string s)
        {
            string result = string.Empty;
            Dictionary<char, string> d = new Dictionary<char, string>()
            {
                {'A',"T"},{'T',"A"},{'C',"G"},{'G',"C"}
            };
            for (int i = s.Length - 1; i >= 0; i--)
            {
                result += d[s[i]];
            }
            return result;
        }
    }
}
