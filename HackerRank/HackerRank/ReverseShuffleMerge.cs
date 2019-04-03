using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public class ReverseShuffleMerge
    {
        public static void Execute()
        {
            string s = Console.ReadLine();

            string result = reverseShuffleMerge(s);

            Console.WriteLine(result);
        }

        public static string reverseShuffleMerge(string s)
        {
            string result = string.Empty;
            Dictionary<char, int> d = new Dictionary<char, int>(), allowance;

            for (int i = 0; i < s.Length; i++)
            {
                if (!d.ContainsKey(s[i]))
                {
                    d.Add(s[i], 1);
                }
                else
                {
                    d[s[i]]++;
                }
            }

            d = d.ToDictionary(pair => pair.Key, pair => pair.Value / 2);
            allowance = new Dictionary<char, int>(d);

            var smallest = d.Where(x => x.Value != 0).Min(x => x.Key);

            bool add = false;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (d[s[i]] > 0)
                {
                    if (s[i] == smallest || allowance[s[i]] == 0)
                    {
                        add = true;
                    }
                    else if (i - 1 >= 0)
                    {
                        var temp = new Dictionary<char, int>(allowance);
                        for (int j = i - 1; j >= 0; j--)
                        {
                            if (d[s[j]] == 0)
                            {
                                continue;
                            }

                            if (s[j] < s[i])
                            {
                                break;
                            }

                            if (temp[s[j]] == 0)
                            {
                                add = true;
                                break;
                            }

                            temp[s[j]]--;
                        }
                    }
                }

                if (add)
                {
                    d[s[i]]--;
                    result += s[i];

                    if (d[smallest] == 0)
                    {
                        smallest = d.Any(x => x.Value != 0) ? d.Where(x => x.Value != 0).Min(x => x.Key) : d.Max(x => x.Key);
                    }
                }
                else
                {
                    allowance[s[i]]--;
                }

                add = false;
            }

            return result;
        }
    }
}
