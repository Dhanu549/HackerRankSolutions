using System;

namespace HackerRank
{
    public static class MarkAndToys
    {
        public static void Execute()
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int[] prices = Array.ConvertAll(Console.ReadLine().Split(' '), pricesTemp => Convert.ToInt32(pricesTemp))
            ;
            int result = maximumToys(prices, k);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        static int maximumToys(int[] prices, int k)
        {
            int maxToys = 0, moneySum = 0;

            quickSort(prices, 0, prices.Length - 1);
            for (int i = 0; i < prices.Length && moneySum + prices[i] <= k; i++)
            {
                maxToys++;
                moneySum += prices[i];
            }
            return maxToys;
        }

        static void quickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = partition(arr, low, high);
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi, high);
            }
        }

        static int partition(int[] arr, int low, int high)
        {
            int pivot = arr[(low + high) / 2];
            while (low <= high)
            {
                while (arr[low] < pivot)
                    low++;
                while (arr[high] > pivot)
                    high--;
                if (low <= high)
                {
                    int temp = arr[low];
                    arr[low] = arr[high];
                    arr[high] = temp;
                    low++;
                    high--;
                }
            }
            return low;            
        }
    }
}
