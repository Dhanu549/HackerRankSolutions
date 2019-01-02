using System;

namespace HackerRank
{
    public static class JumpOnClouds
    {
        public static void Execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp));
            int result = jumpingOnClouds(c);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        static int jumpingOnClouds(int[] c)
        {
            int result = 0;
            for(int i =1; i< c.Length; i++)
            {
                if(i != c.Length-1 && c[i+1] == 0)
                {
                    i++;
                }
                result++;
            }
            return result;
        }
    }
}
