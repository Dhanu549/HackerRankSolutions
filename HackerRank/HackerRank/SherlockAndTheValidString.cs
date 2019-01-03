using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static class SherlockAndTheValidString
    {
        public static void Execute()
        {
            string s = Console.ReadLine();

            string result = isValid(s);

            Console.WriteLine(result);
        }

        private static string isValid(string s)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            SortedDictionary<int, int> counts = new SortedDictionary<int, int>();

            foreach (char c in s)
            {
                if(d.ContainsKey(c-'a'))
                {
                    int count = ++d[c - 'a'];
                    if (counts.ContainsKey(count))
                    {
                        counts[count]++;
                    }
                    else
                    {
                        counts.Add(count, 1);
                    }
                    if (counts.ContainsKey(count - 1) && counts[count-1] >= 0)
                    {
                        counts[count - 1]--;
                        if (counts[count - 1] == 0)
                            counts.Remove(count - 1);
                    }
                    else
                    {
                        counts.Add(count - 1, 1);
                    }
                }
                else
                {
                    d.Add(c - 'a', 1);
                    if (counts.ContainsKey(1))
                        counts[1]++;
                    else
                        counts.Add(1, 1);
                }
            }
            
            if (counts.Count == 1 || 
                (counts.Count == 2 && ((counts.ElementAt(0).Key == 1 && counts.ElementAt(0).Value == 1) ||
                        counts.ElementAt(1).Key - counts.ElementAt(0).Key == 1 && counts.ElementAt(1).Value == 1)))
                return "YES";
            else
                return "NO";
        }
    }
}
