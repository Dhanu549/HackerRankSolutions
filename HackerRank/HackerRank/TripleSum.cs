using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public static class TripleSum
    {
        public static void Execute()
        {
            string[] lenaLenbLenc = Console.ReadLine().Split(' ');

            int lena = Convert.ToInt32(lenaLenbLenc[0]);

            int lenb = Convert.ToInt32(lenaLenbLenc[1]);

            int lenc = Convert.ToInt32(lenaLenbLenc[2]);

            int[] arra = Array.ConvertAll(Console.ReadLine().Split(' '), arraTemp => Convert.ToInt32(arraTemp))
            ;

            int[] arrb = Array.ConvertAll(Console.ReadLine().Split(' '), arrbTemp => Convert.ToInt32(arrbTemp))
            ;

            int[] arrc = Array.ConvertAll(Console.ReadLine().Split(' '), arrcTemp => Convert.ToInt32(arrcTemp))
            ;
            long ans = triplets(arra, arrb, arrc);

            Console.WriteLine(ans);
        }

        static long triplets(int[] a, int[] b, int[] c)
        {
            /*The SortedDictionary<TKey, TValue> generic class is a binary search tree with O(log n) retrieval, 
             * where n is the number of elements in the dictionary.In this, it is similar to the SortedList<TKey, TValue> generic class. 
             * The two classes have similar object models, and both have O(log n) retrieval.Where the two classes differ is in memory use and speed of insertion and removal:

                    SortedList<TKey, TValue> uses less memory than SortedDictionary<TKey,TValue>.

                    SortedDictionary<TKey, TValue> has faster insertion and removal operations for unsorted data, O(log n) as opposed to O(n) for  SortedList<TKey, TValue>.

                    If the list is populated all at once from sorted data, SortedList<TKey,TValue> is faster than  SortedDictionary<TKey, TValue>.

            (SortedList actually maintains a sorted array, rather than using a tree.It still uses binary search to find elements.)*/

            long result = 0;
            SortedList<int, int> da = new SortedList<int, int>();
            SortedList<int, int> db = new SortedList<int, int>();
            SortedList<int, int> dc = new SortedList<int, int>();
            foreach (int i in a)
                da[i] = 1;
            foreach (int i in b)
                db[i] = 1;
            foreach (int i in c)
                dc[i] = 1;

            long m = 0, n = 0;
            int j = 0, k = 0;
            List<int> la = da.Keys.ToList();
            List<int> lc = dc.Keys.ToList();

            foreach (int i in db.Keys)
            {
                for (; j < la.Count && la[j] <= i; j++)
                    m++;
                for (; k < lc.Count && lc[k] <= i; k++)
                    n++;
                result += m * n;
            }

            return result;
        }
    }
}
