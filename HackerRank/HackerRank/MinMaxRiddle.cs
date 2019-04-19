using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public class MinMaxRiddle
    {
        public static void Execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt64(arrTemp));
            long[] res = riddle(arr);

            Console.WriteLine(string.Join(" ", res));
        }

        static long MaxWin(long i, long[] pair, Dictionary<long, long> maxWin) =>
        !maxWin.ContainsKey(pair[1]) || maxWin[pair[1]] < i - pair[0]
        ? i - pair[0]
        : maxWin[pair[1]];

        public static long[] riddle(long[] arr)
        {
            long[] pair;

            var maxWin = new Dictionary<long, long>();
            var stack = new Stack<long[]>(); // No ValueTuples on hr
            foreach (var now in arr.Select((v, i) => new { v, i }))
            {
                pair = new[] { now.i, now.v };
                if (stack.Count == 0 || now.v > stack.Peek()[1])
                {
                    stack.Push(pair);
                }
                else
                {
                    while (stack.Count > 0 && now.v < stack.Peek()[1])
                    {
                        pair = stack.Pop();
                        maxWin[pair[1]] = MaxWin(now.i, pair, maxWin);
                    }
                    stack.Push(new[] { pair[0], now.v });
                }
            }
            while (stack.Count > 0)
            {
                pair = stack.Pop();
                maxWin[pair[1]] = MaxWin(arr.Length, pair, maxWin);
            }

            var winMax = new Dictionary<long, long>();
            foreach (var kvp in maxWin)
            {
                if (!winMax.ContainsKey(kvp.Value) || kvp.Key > winMax[kvp.Value])
                    winMax[kvp.Value] = kvp.Key;
            }

            var result = new long[arr.Length];
            var max = long.MinValue;
            for (var i = arr.Length; i >= 1; i--)
            {
                max = winMax.ContainsKey(i) && winMax[i] > max ? winMax[i] : max;
                result[i - 1] = max;
            }
            return result;
        }

        static long[] riddle1(long[] arr)
        {
            long[] result = new long[arr.Length];
            Stack<long> s1 = new Stack<long>();
            Stack<long> s2 = new Stack<long>();
            long max = 0;
            for (int i =0; i< arr.Length;i++)
            {
                s1.Push(arr[i]);
                if (arr[i] > max)
                    max = arr[i];
            }
            result[0] = max;
            for (int i = 1; i< arr.Length;i++)
            {
                max = 0;
                if(s1.Count > 1)
                {
                    while (s1.Count > 1)
                    {
                        long currentMin = Math.Min(s1.Pop(), s1.Peek());
                        if (currentMin > max)
                            max = currentMin;
                        s2.Push(currentMin);
                    }
                    s1.Pop();
                    result[i] = max;
                }
                else
                {
                    while (s2.Count > 1)
                    {
                        long currentMin = Math.Min(s2.Pop(), s2.Peek());
                        if (currentMin > max)
                            max = currentMin;
                        s1.Push(currentMin);
                    }
                    s2.Pop();
                    result[i] = max;
                }
            }
            return result;
        }
    }
}
