using System;

namespace HackerRank
{
    public static class TwoStrings
    {
        public static void Execute()
        {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s1 = Console.ReadLine();

                string s2 = Console.ReadLine();

                string result = twoStrings(s1, s2);

                Console.WriteLine(result);
            }
        }

        static string twoStrings(string s1, string s2)
        {
            bool containChar = false;
            for (char ch = 'a'; ch < 'z'; ch++)
            {
                if (s1.Contains(ch) && s2.Contains(ch))
                {
                    containChar = true;
                    break;
                }
            }
            if (containChar)
                return "YES";
            else
                return "NO";

            //if(s1.Length < s2.Length)
            //{
            //    foreach (char c in s2)
            //    {
            //        if (s1.Contains(c))
            //        {
            //            containChar = true;
            //            break;
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (char c in s1)
            //    {
            //        if (s2.Contains(c))
            //        {
            //            containChar = true;
            //            break;
            //        }
            //    }
            //}


        }
    }
}
