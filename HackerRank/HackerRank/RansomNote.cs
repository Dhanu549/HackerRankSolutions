using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static class RansomNote
    {
        public static void Execute()
        {
            string[] mn = Console.ReadLine().Split(' ');

            int m = Convert.ToInt32(mn[0]);

            int n = Convert.ToInt32(mn[1]);

            string[] magazine = Console.ReadLine().Split(' ');

            string[] note = Console.ReadLine().Split(' ');

            checkMagazine(magazine, note);
        }

        static void checkMagazine(string[] magazine, string[] note)
        {
            bool canComplete = true;
            /*Hash Table version */
            //Hashtable ht = new Hashtable();
            //foreach (string word in magazine)
            //{
            //    if (ht.ContainsKey(word))
            //        ht[word] = Convert.ToInt32(ht[word]) + 1;
            //    else
            //        ht.Add(word, 1);
            //}
            //foreach (string word in note)
            //{
            //    if (ht.ContainsKey(word))
            //    {
            //        if (Convert.ToInt32(ht[word]) == 1)
            //            ht.Remove(word);
            //        else
            //            ht[word] = Convert.ToInt32(ht[word]) - 1;
            //    }
            //    else
            //    {
            //        canComplete = false;
            //        break;
            //    }
            //}

            /*Dictionary Version*/
            Dictionary<string,int> d = new Dictionary<string, int>();
            foreach (string word in magazine)
            {
                if (d.ContainsKey(word))
                    d[word]++;
                else
                    d.Add(word, 1);
            }

            foreach (string word in note)
            {
                if (d.ContainsKey(word))
                {
                    if (d[word] == 1)
                        d.Remove(word);
                    else
                        d[word]--;
                }
                else
                {
                    canComplete = false;
                    break;
                }
            }                     

            if (canComplete)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}
