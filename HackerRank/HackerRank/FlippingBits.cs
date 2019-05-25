using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class FlippingBits
    {
        public static void Execute()
        {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                long n = Convert.ToInt64(Console.ReadLine());

                long result = flippingBits(n);

                Console.WriteLine(result);
            }

        }

        private static long flippingBits(long n)
        {
            return (long)Math.Pow(2, 32) - 1 - n;
        }
    }
}
