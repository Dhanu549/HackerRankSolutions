using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static class HourGlassSum
    {
        public static void Execute()
        {
            int[][] arr = new int[6][];

            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = hourglassSum(arr);

            Console.WriteLine(result);
        }

        private static int hourglassSum(int[][] arr)
        {
            List<int> l = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    l.Add(arr[i][j] + arr[i][j + 1] + arr[i][j + 2] 
                        + arr[i + 1][j + 1] 
                        + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2]);
                }
            }
            return l.Max();
        }
        
    }
}
