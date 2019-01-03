using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public static class SherlockAndAnagrams
    {
        public static void Execute()
        {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = sherlockAndAnagrams(s);

                Console.WriteLine(result);
            }
        }

        static int sherlockAndAnagrams(string s)
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            for (int i = 0; i < s.Length; i++)                
            {
                int[] charCount = new int[26];
                for(int j=i;j<s.Length;j++)
                {
                    int aCode = s[j] - 'a';
                    charCount[aCode]++;
                    string key = GiveKey(charCount);
                    if (!d.ContainsKey(key))
                        d.Add(key, 0);
                    d[key]++;
                }                
            }
            int total = 0;
            foreach(var item in d)
            {
                if(item.Value > 1)
                {
                    total += item.Value * (item.Value - 1) / 2;
                }
            }
            return total;
        }
        static string GiveKey(int[] arr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 26; i++)
            {
                sb.AppendFormat("{0}-", arr[i]);
            }
            return sb.ToString();
        }
    }
}
