using System;

namespace HackerRank
{
    public static class ArrayModification
    {
        public static void Execute()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            double[] A = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            double max1 = 0, max2 = 0, min = double.MaxValue, c = 0;
            double sum = 0;
            double nMax1 = double.MinValue, nMax2 = double.MinValue, nMin = 1, nc =0;
            double nSum = 0;
            for (int i = 0; i < N; i++)
            {
                if(A[i] > 0)
                {
                    c++;
                    if (A[i] >= max1)
                    {
                        max2 = max1;
                        max1 = A[i];
                    }
                    else if (A[i] > max2)
                    {
                        max2 = A[i];
                    }
                    if (A[i] < min)
                        min = A[i];
                    sum += A[i];
                }
                else
                {
                    nc++;
                    if (A[i] >= nMax1)
                    {
                        nMax2 = nMax1;
                        nMax1 = A[i];
                    }
                    else if (A[i] > nMax2)
                    {
                        nMax2 = A[i];
                    }
                    if (A[i] < nMin)
                        nMin = A[i];
                    nSum += A[i];
                }
            }
            double result = 0;
            if (c >= 2 && nc >= 2)
                result = (((sum - max1 + max2) * max1) % (double)(Math.Pow(10, 9) + 7) +
                ((nSum - nMax1 + nMax2) * nMax1) % (double)(Math.Pow(10, 9) + 7)) % (double)(Math.Pow(10, 9) + 7);
            else if(c>=2)
            {
                if (nc == 0)
                    result = ((sum - max1 + max2) * max1) % (double)(Math.Pow(10, 9) + 7);
                else if (nc ==1)
                    result = (((sum - max1 + max2) * max1) % (double)(Math.Pow(10, 9) + 7) +
                nMax1*min) % (double)(Math.Pow(10, 9) + 7);
            }
            else
            {
                if (c == 0)
                    result = ((nSum - nMax1 + nMax2) * nMax1) % (double)(Math.Pow(10, 9) + 7);
                else if (nc == 1)
                    result = (((nSum - nMax1 + nMax2) * nMax1) % (double)(Math.Pow(10, 9) + 7) +
                max1 * nMin) % (double)(Math.Pow(10, 9) + 7);
            }

            Console.WriteLine((long)result);
        }
    }
}
