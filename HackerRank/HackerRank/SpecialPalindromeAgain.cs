using System;

namespace HackerRank
{
    public static class SpecialPalindromeAgain
    {
        public static void Execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            string s = Console.ReadLine();

            long result = substrCount(n, s);

            Console.WriteLine(result);
        }

        static long substrCount(int n, string s)
        {
            long retVal = s.Length;

            for (int i = 0; i < s.Length; i++)
            {
                var startChar = s[i];
                int diffCharIdx = -1;
                for (int j = i + 1; j < s.Length; j++)
                {
                    var currChar = s[j];
                    if (startChar == currChar)
                    {
                        if ((diffCharIdx == -1) ||
                           (j - diffCharIdx) == (diffCharIdx - i))
                            retVal++;
                    }
                    else
                    {
                        if (diffCharIdx == -1)
                            diffCharIdx = j;
                        else
                            break;
                    }
                }
            }
            return retVal;
        }

        //static long substrCount2(int n, string s)
        //{
        //    long count = n;
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int l = 2; l <= n - i; l++)
        //        {
        //            string subStr = s.Substring(i, l);
        //            var check = isSpecialPalindrome(subStr);
        //            if (check.Item1)
        //            {
        //                count++;
        //            }
        //            if (check.Item2)
        //                break;
        //        }
        //    }
        //    return count;
        //}

        //static Tuple<bool,bool> isSpecialPalindrome(string subStr)
        //{
        //    int len = subStr.Length;
        //    char c = subStr[0];

        //    for (int i = 0; i < len / 2; i++)
        //    {
        //        if (subStr[i] != c || subStr[len - i - 1] != c)
        //        {
        //            return Tuple.Create(false,false);
        //        }
        //    }

        //    if (len % 2 == 1 && subStr[len / 2] != c)
        //        return Tuple.Create(true, true);
        //    return Tuple.Create(true,false);
        //}
    }
}
