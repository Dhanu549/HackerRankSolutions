using System;
using System.Collections.Generic;
using System.IO;

namespace HackerRank
{
    public static class SockMerchant
    {
        public static void Execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] strs = Console.ReadLine().Split(' ');
            int[] arr = new int[n];
            int i = 0;
            foreach (string s in strs)
            {
                if (Int32.TryParse(s, out int val))
                {
                    arr[i++] = val;
                }
            }
            //int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => { int val; if (Int32.TryParse(arTemp, out val)) return new Converter<string,int>(arTemp); });
            int result = sockMerchant(n, arr);
            Console.WriteLine(result);
            Console.ReadLine();            
        }

        private static int sockMerchant(int n, int[] ar)
        {
            int result = 0;
            Dictionary<int, int> socks = new Dictionary<int, int>();
            for(int i=0; i < n; i++)
            {
                if (socks.ContainsKey(ar[i]))
                {
                    socks[ar[i]]++;
                }
                else
                {
                    socks.Add(ar[i], 1);
                }
            }
            foreach(var sock in socks)
            {
                result += (sock.Value / 2);                
            }
            return result;
        }
    }
}
