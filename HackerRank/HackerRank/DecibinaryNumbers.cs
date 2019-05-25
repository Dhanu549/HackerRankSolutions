using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class DecibinaryNumbers
    {
        public static void Execute()
        {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                long x = Convert.ToInt64(Console.ReadLine());

                long result = decibinaryNumbers(x);

                Console.WriteLine(result);
            }
        }

        private static long decibinaryNumbers(long x)
        {
            throw new NotImplementedException();
        }
    }
}
