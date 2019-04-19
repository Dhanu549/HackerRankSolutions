using System;
using System.Collections.Generic;

namespace HackerRank
{
    public class GCDMatrix
    {
        public static void Execute()
        {
            string[] nmq = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nmq[0]);

            int m = Convert.ToInt32(nmq[1]);

            int q = Convert.ToInt32(nmq[2]);

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

            int[] b = Array.ConvertAll(Console.ReadLine().Split(' '), bTemp => Convert.ToInt32(bTemp));

            int[,] matrix = new int[n,m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrix[i, j] = gcd(a[i], b[j]);

            for (int qItr = 0; qItr < q; qItr++)
            {
                string[] r1C1R2C2 = Console.ReadLine().Split(' ');

                int r1 = Convert.ToInt32(r1C1R2C2[0]);

                int c1 = Convert.ToInt32(r1C1R2C2[1]);

                int r2 = Convert.ToInt32(r1C1R2C2[2]);

                int c2 = Convert.ToInt32(r1C1R2C2[3]);

                Dictionary<int, int> d = new Dictionary<int, int>();

                for (int i = r1; i <= r2; i++)
                    for (int j = c1; j <= c2; j++)
                    {
                        if (d.ContainsKey(matrix[i, j]))
                            d[matrix[i, j]]++;
                        else
                            d.Add(matrix[i, j], 1);
                    }
                Console.WriteLine(d.Count);
            }
        }

        static int gcd(int a, int b)
        {            
            if (a == 1 || b == 1)
                return 1;
            if (a == b)
                return a;

            if (a > b)
                return gcd(a - b, b);
            return gcd(a, b - a);
        }

        static int gcdNonRecursive(int a, int b)
        {
            while (a != b)
                if (a > b)
                    a -= b;
                else
                    b -= a;

            return a;

            //int gcd = 1;

            //for(int i=1;i<=a&&i<=b;i++)
            //    if (a % i == 0 && b % i == 0)
            //        gcd = i;
            //return gcd;
        }
    }
}
