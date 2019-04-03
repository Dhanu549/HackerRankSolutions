using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public static class OptimalRouteUtilization
    {
        public static void Execute()
        {
            int[,] arr = new int[,] { { 1, 2 }, { 3, 4 }, { 1, -1 } };
            var res = optimalUtilization(10000, 
                new List<List<int>>() { new List<int>(){ 1, 3000}, new List<int>() { 2, 5000}, new List<int>() {3,7000 }, new List<int>() {4, 10000 } }, 
                new List<List<int>>() { new List<int>() { 1, 2000}, new List<int>() {2, 3000 }, new List<int>() {3, 4000 }, new List<int>() { 4, 5000 } });
            Console.ReadLine();
        }
        public static List<List<int>> optimalUtilization(int maxTravelDist,
                                        List<List<int>> forwardRouteList,
                                        List<List<int>> returnRouteList)
        {
            //SortedDictionary<long, List<List<int>>> d = new SortedDictionary<long, List<List<int>>>();
            //for (int i = 0; i < forwardRouteList.Count; i++)
            //{
            //    for (int j = 0; j < returnRouteList.Count; j++)
            //    {
            //        long distace = forwardRouteList[i][1] + returnRouteList[j][1];
            //        if (distace <= maxTravelDist)
            //        {
            //            if (d.ContainsKey(distace))
            //                d[distace].Add(new List<int>() { forwardRouteList[i][0], returnRouteList[j][0] });
            //            else
            //                d.Add(distace, new List<List<int>>() { new List<int>() { forwardRouteList[i][0], returnRouteList[j][0] } });
            //        }
            //    }
            //}
            //if (d.Count >= 1)
            //    return d.Last().Value;
            //else
            //    return new List<List<int>>();

            List<List<int>> result = new List<List<int>>();
            long optimalDistance = 0;
            for (int i = 0; i < forwardRouteList.Count; i++)
            {
                for (int j = 0; j < returnRouteList.Count; j++)
                {
                    long distance = forwardRouteList[i][1] + returnRouteList[j][1];
                    if (distance <= maxTravelDist)
                    {
                        if(distance > optimalDistance)
                        {
                            optimalDistance = distance;
                            result = new List<List<int>>();
                            result.Add(new List<int>() { forwardRouteList[i][0], returnRouteList[j][0] });
                        }
                        else if (distance == optimalDistance)
                        {
                            optimalDistance = distance;
                            result.Add(new List<int>() { forwardRouteList[i][0], returnRouteList[j][0] });
                        }
                    }
                }
            }
            if (optimalDistance == 0)
                return new List<List<int>>();
            else
                return result;
        }
    }
}

