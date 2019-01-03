using System;

namespace HackerRank
{
    public static class RollerCoasterBribe
    {
        public static void Execute()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp))
                ;
                minimumBribes(q);
            }
        }

        static void minimumBribes(int[] q)
        {
            int result = 0;
            bool chaotic = false;
            for (int i = 0; i < q.Length; i++)
            {
                int bribe = q[i] - (i + 1);
                if (bribe > 2)
                {
                    chaotic = true;
                    break;
                }
                for (int j = Math.Max(0, q[i] - 2); j < i; j++)
                    if (q[j] > q[i])
                        result++;
            }
            
            if (chaotic)
                Console.WriteLine("Too chaotic");
            else
                Console.WriteLine(result);
        }
    }
}
