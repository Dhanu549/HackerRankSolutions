using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public static class ConsecutiveToRange
    {
        public static void Execute()
        {
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), temp => Convert.ToInt32(temp));
            printRanges(arr);
        }

        static void printRanges(int[] arr)
        {
            int start = arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] != arr[i + 1] - 1)
                {
                    Console.WriteLine($"{start} {arr[i]}");
                    start = arr[i + 1];
                }
            }
            Console.WriteLine($"{start} {arr[arr.Length - 1]}");

            //int end = arr[arr.Length - 1];
            //int previous = end;
            //Stack<int> s = new Stack<int>();
            //for (int i = 0; i < arr.Length -1; i++)
            //    s.Push(arr[i]);
            //while(s.TryPop(out int current))
            //{
            //    if (current != previous - 1)
            //    {
            //        Console.WriteLine($"{previous} {end}");
            //        end = current;
            //    }
            //    previous = current;
            //}
            //Console.WriteLine($"{previous} {end}");
        }
    }
}
