using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public static class NearestDestinations
    {
        public static void Execute()
        {
            int[,] arr = new int[,] { { 1, 2 }, { 3, 4 }, { 1, -1 } };
            var res = ClosestXdestinations(3, arr, 1);
            Console.ReadLine();
        }

        public static List<List<int>> ClosestXdestinations(int numDestinations,
                                            int[,] allLocations,
                                            int numDeliveries)
        {
            // WRITE YOUR CODE HERE
            List<List<int>> result = new List<List<int>>();
            SortedDictionary<double, List<List<int>>> d = new SortedDictionary<double, List<List<int>>>();
            for (int i = 0; i < numDestinations; i++)
            {
                double distace = Math.Sqrt((allLocations[i, 0] * allLocations[i, 0]) + (allLocations[i, 1] * allLocations[i, 1]));
                if (d.ContainsKey(distace))
                    d[distace].Add(new List<int>() { allLocations[i, 0], allLocations[i, 1] });
                else
                    d.Add(distace, new List<List<int>>() { new List<int>() { allLocations[i, 0], allLocations[i, 1] } });
            }
            foreach (var item in d)
            {
                if (item.Value.Count <= (numDeliveries - result.Count))
                    result.AddRange(item.Value);
                else
                    result.AddRange(item.Value.Take(numDeliveries - result.Count).ToList());
            }

            return result;
        }
    }
}
