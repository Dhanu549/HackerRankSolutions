using System;
using System.Collections.Generic;

namespace HackerRank
{
    public static class MinSwaps2
    {
        public static void Execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int result = lilysHomework(arr);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        static int lilysHomework(int[] arr)
        {
            int[] sortedArray = (int[])arr.Clone();
            //int[] arrCopy = new int[arr.Length];
            //Array.Copy(arr, arrCopy, arr.Length);

            Dictionary<int,int> d = new Dictionary<int, int>();
            for (var i = 0; i < arr.Length; i++)
            {
                d[arr[i]] = i;
            }

            Array.Sort(sortedArray);
            //quickSort(sortedArray, 0, arr.Length - 1);
            int swaps = Count(arr, sortedArray, d); //minSwaps(arr, sortedArray);

            Array.Reverse(sortedArray);
            int swapsDesc = Count(arr, sortedArray, d); //minSwaps(arrCopy, sortedArray);

            return swaps <= swapsDesc ? swaps : swapsDesc;
        }

        static int Count(int[] a, int[] sorted, Dictionary<int, int> map)
        {
            var arr = new int[a.Length];
            Array.Copy(a, arr, arr.Length);

            var mapCopy = new Dictionary<int, int>();
            foreach (var kv in map)
            {
                mapCopy[kv.Key] = kv.Value;
            }

            var count = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] != sorted[i])
                {
                    count++;
                    var indexToSwap = mapCopy[sorted[i]];
                    mapCopy[arr[i]] = indexToSwap;

                    var tmp = arr[i];
                    arr[i] = arr[indexToSwap];
                    arr[indexToSwap] = tmp;
                }
            }

            return count;
        }

        static int minSwaps(int[] arr, int[] sortedArray)
        {
            int swaps = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] != sortedArray[i])
                    for (int j = i + 1; j < arr.Length; j++)
                        if (arr[j] == sortedArray[i])
                        {
                            arr[j] = arr[i];
                            arr[i] = sortedArray[i];
                            swaps++;
                            break;
                        }
            return swaps;
        }

        static void quickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pi = partition(arr, left, right);
                quickSort(arr, left, pi - 1);
                quickSort(arr, pi, right);
            }
        }

        static int partition(int[] arr, int left, int right)
        {
            int pivot = arr[(left + right) / 2];
            while (left <= right)
            {
                while (arr[left] < pivot)
                    left++;
                while (arr[right] > pivot)
                    right--;
                if (left <= right)
                {
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    left++;
                    right--;
                }
            }
            return left;
        }
    }
}
