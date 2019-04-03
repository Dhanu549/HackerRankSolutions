using System;
using System.Collections.Generic;

namespace HackerRank
{
    public class BalancedBrackets
    {
        public static void Execute()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string s = Console.ReadLine();

                string result = isBalanced(s);

                Console.WriteLine(result);
            }
        }

        static string isBalanced(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> d = new Dictionary<char, char>()
            {
                {'{', '}'},
                {'[', ']'},
                {'(', ')'}
            };

            foreach(char c in s)
            {
                if (d.ContainsKey(c))
                    stack.Push(c);
                else if (stack.Count > 0 && d[stack.Pop()] == c) //stack.TryPop(out char top) && d[top] == c
                    continue;
                else
                    return "NO";
            }

            if (stack.Count > 0)
                return "NO";

            return "YES";
        }
    }
}
