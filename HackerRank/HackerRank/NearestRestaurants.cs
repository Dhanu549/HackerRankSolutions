using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public static class NearestRestaurants
    {
        public static void Execute()
        {
            int[,] arr = new int[,] { { 1, -3 },{ 1, 2 },{ 3, 4 } };
            var res = nearestVegetarianRestaurant(3, arr, 1);
            Console.ReadLine();
        }
        public static List<List<int>> nearestVegetarianRestaurant(int totalRestaurants,
                                                       int[,] allLocations,
                                                       int numRestaurants)
        {
            // WRITE YOUR CODE HERE
            List<List<int>> result = new List<List<int>>();
            SortedDictionary<double, List<List<int>>> dict = new SortedDictionary<double, List<List<int>>>();
            for (int i = 0; i < totalRestaurants; i++)
            {
                double val = Math.Sqrt((allLocations[i, 0] * allLocations[i, 0]) + (allLocations[i, 1] * allLocations[i, 1]));
                if (dict.ContainsKey(val))
                {
                    dict[val].Add(new List<int>() { allLocations[i, 0], allLocations[i, 1] });
                }
                else
                {
                    dict.Add(val, new List<List<int>>() { new List<int>() { allLocations[i, 0], allLocations[i, 1] } });
                }
            }
            foreach (var item in dict)
            {
                //foreach (var l in item.Value)
                //{
                    if (item.Value.Count <= (numRestaurants - result.Count))
                    {
                        result.AddRange(item.Value);
                    }
                    else
                    {
                        result.AddRange(item.Value.Take(numRestaurants - result.Count).ToList());
                    }
                //}
            }
            return result;
        }
    }
}
