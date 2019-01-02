using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static class MinSwaps
    {
        public static void Execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int res = minimumSwaps(arr);

            Console.WriteLine(res);
            Console.ReadLine();
        }
        static int minimumSwaps(int[] arr)
        {
            int swaps = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != i + 1)                    
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if(arr[j] == i+1)
                        {
                            arr[j] = arr[i];
                            arr[i] = i + 1;
                            swaps++;
                            break;
                        }
                    }
                }
            }
            return swaps;
        }
    }
}
