using System;
using System.Collections.Generic;

namespace HackerRank
{
    public class LargestRectangle
    {
        public static void Execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] h = Array.ConvertAll(Console.ReadLine().Split(' '), hTemp => Convert.ToInt32(hTemp));
            long result = largestRectangle(h);

            Console.WriteLine(result);
        }

        static long largestRectangle(int[] h)
        {
            long maxArea = 0;
            Stack<int> s = new Stack<int>();
            int i = 0;

            while (i < h.Length)
            {
                if (s.Count == 0 || h[s.Peek()] <= h[i])
                {
                    s.Push(i);
                    i++;
                }
                else
                {
                    int top = s.Pop();
                    if (s.Count == 0)
                        maxArea = Math.Max(h[top] * i, maxArea);
                    else
                        maxArea = Math.Max(h[top] * (i - (s.Peek() + 1)), maxArea);
                }
            }

            while (s.Count > 0)
            {
                int top = s.Pop();
                if (s.Count == 0)
                    maxArea = Math.Max(h[top] * i, maxArea);
                else
                    maxArea = Math.Max(h[top] * (i - (s.Peek() + 1)), maxArea);
            }

            return maxArea;
        }
    }
}
