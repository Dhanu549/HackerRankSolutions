using System;
using System.Collections.Generic;

namespace HackerRank
{
    public static class FraudulentActivityNotifications
    {
        public static void Execute()
        {
            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp));
            int result = activityNotifications(expenditure, d);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        static int activityNotifications(int[] expenditure, int d)
        {
            int notificationCount = 0;

            int[] data = new int[201];
            for (int i = 0; i < d; i++)
            {
                data[expenditure[i]]++;
            }

            for (int i = d; i < expenditure.Length; i++)
            {
                double median = getMedian(d, data);
                if (expenditure[i] >= 2 * median)
                    notificationCount++;

                data[expenditure[i]]++;
                data[expenditure[i - d]]--;
            }

            return notificationCount;
        }

        static double getMedian(int d, int[] data)
        {
            double median = 0, count = 0;
            if(d%2==0)
            {
                int m1 = 0, m2 = 0;
                for (int j = 0; j < data.Length; j++)
                {
                    count += data[j];
                    if (m1 == 0 && count >= d / 2)
                    {
                        m1 = j;
                    }
                    if (m2 == 0 && count >= d / 2 + 1)
                    {
                        m2 = j;
                        break;
                    }
                }
                median = (m1 + m2) / 2.0;
            }
            else
            {
                for(int j=0;j<data.Length;j++)
                {
                    count += data[j];
                    if(count>d/2)
                    {
                        median = j;
                        break;
                    }
                }
            }
            return median;
        }

        static int activityNotifications1(int[] expenditure, int d)
        {
            int notifications = 0;
            List<int> l = new List<int>();
            for(int i=0;i<d;i++)
            {
                l.Add(expenditure[i]);
            }
            quickSort(l, 0, d - 1);
            if (d % 2 == 1)
                for (int i = d; i < expenditure.Length; i++)
                {
                    float median = 0;
                    median = l[d / 2];
                    if (expenditure[i] >= 2 * median)
                        notifications++;
                    l.Remove(expenditure[i - d]);
                    insertionSort(l, expenditure[d]);
                }
            else
                for (int i = d; i < expenditure.Length; i++)
                {
                    float median = 0;
                    median = (float)(l[d / 2 - 1] + l[d / 2]) / 2;
                    if (expenditure[i] >= 2 * median)
                        notifications++;
                    l.Remove(expenditure[i - d]);
                    insertionSort(l, expenditure[d]);
                }
            return notifications;
        }

        static void insertionSort(List<int> arr, int ele)
        {
            arr.Add(ele);            
            for (int i = arr.Count - 1; i > 0 ; i--)
            {
                if (arr[i - 1] > arr[i])
                {
                    int temp = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = temp;
                }
                else
                    break;
            }
        }

        static int activityNotifications2(int[] expenditure, int d)
        {
            int notifications = 0;
            if (d % 2 == 1)
                for (int i = d; i < expenditure.Length; i++)
                {
                    float median = 0;
                    //quickSort(expenditure, i - d, i - 1);
                    median = expenditure[i - (d + 1) / 2];
                    if (expenditure[i] >= 2 * median)
                        notifications++;
                }
            else
                for (int i = d; i < expenditure.Length; i++)
                {
                    float median = 0;
                    //quickSort(expenditure, i - d, i - 1);
                    median = (float)(expenditure[i - (d + 1) / 2] + expenditure[i - d / 2]) / 2;
                    if (expenditure[i] >= 2 * median)
                        notifications++;
                }
            return notifications;
        }

        static void quickSort(List<int> arr, int left, int right)
        {
            if (left < right)
            {
                int pi = partition(arr, left, right);
                quickSort(arr, left, pi - 1);
                quickSort(arr, pi, right);
            }
        }

        static int partition(List<int> arr, int left, int right)
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
