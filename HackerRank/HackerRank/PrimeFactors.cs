using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class PrimeFactors
    {
        public static void Execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 2; n > 1; i++)
                if (n % i == 0)
                {
                    int x = 0;
                    while (n % i == 0)
                    {
                        n /= i;
                        x++;
                    }
                    Console.WriteLine("{0} is a prime factor {1} times!", i, x);
                }
        }
    }
}
