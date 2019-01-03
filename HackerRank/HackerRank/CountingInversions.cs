using System;

namespace HackerRank
{
    public static class CountingInversions
    {
        public static void Execute()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
                long result = countInversions(arr);

                Console.WriteLine(result);
            }
        }

        public static long countInversions(int[] arr)
        {
            return mergeSort(arr, 0, arr.Length - 1);
        }

        public static long mergeSort(int[] arr, int start, int end)
        {
            if (start == end)
                return 0;
            int mid = (start + end) / 2;
            long count = 0;
            count += mergeSort(arr, start, mid); //left inversions
            count += mergeSort(arr, mid + 1, end);//right inversions
            count += merge(arr, start, end); // split inversions.
            return count;
        }

        public static long merge(int[] arr, int start, int end)
        {
            int mid = (start + end) / 2;
            int[] newArr = new int[end - start + 1];
            int curr = 0;
            int i = start;
            int j = mid + 1;
            long count = 0;
            while (i <= mid && j <= end)
            {
                if (arr[i] > arr[j])
                {
                    newArr[curr++] = arr[j++];
                    count += mid - i + 1; // Tricky part.
                }
                else
                    newArr[curr++] = arr[i++];
            }

            while (i <= mid)
            {
                newArr[curr++] = arr[i++];
            }
            while (j <= end)
            {
                newArr[curr++] = arr[j++];
            }

            Array.Copy(newArr, 0, arr, start, end - start + 1);
            return count;
        }

        //static long countInversions(int[] arr)
        //{
        //    int swaps = 0;
        //    int[] a = new int[arr.Length];
        //    Array.Copy(arr, a, arr.Length);

        //    //mergeSort(a, 0, a.Length - 1);
        //    swaps = insertionSort(a);
        //    return swaps;
        //}

        //static int insertionSort(int[] a)
        //{
        //    int swaps = 0;
        //    for (int i = 1; i < a.Length; i++)
        //    {
        //        for (int j = i - 1; j >= 0; j--)
        //        {
        //            if (a[j] > a[i])
        //            {                        
        //                swaps++;
        //            }
        //        }
        //    }
        //    return swaps;
        //}                
    }
}
