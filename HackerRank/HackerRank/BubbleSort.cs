using System;

namespace HackerRank
{
    public static class BubbleSort
    {
        public static void Execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            countSwaps(a);
        }

        private static void countSwaps(int[] a)
        {
            int count = 0;
            for(int i=0;i<a.Length;i++)
            {
                for(int j=0;j<a.Length-1;j++)
                {
                    if(a[j]>a[j+1])
                    {
                        count++;
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine($"Array is sorted in {count} swaps.");
            Console.WriteLine($"First Element: {a[0]}");
            Console.WriteLine($"Last Element: {a[a.Length - 1]}");
        }
    }
}
