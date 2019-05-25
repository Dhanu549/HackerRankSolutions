using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public class RoadsAndLibraries
    {
        public static void Execute()
        {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string[] nmC_libC_road = Console.ReadLine().Split(' ');

                int n = Convert.ToInt32(nmC_libC_road[0]);

                int m = Convert.ToInt32(nmC_libC_road[1]);

                int c_lib = Convert.ToInt32(nmC_libC_road[2]);

                int c_road = Convert.ToInt32(nmC_libC_road[3]);

                int[][] cities = new int[m][];

                for (int i = 0; i < m; i++)
                {
                    cities[i] = Array.ConvertAll(Console.ReadLine().Split(' '), citiesTemp => Convert.ToInt32(citiesTemp));
                }

                long result = roadsAndLibraries(n, c_lib, c_road, cities);

                Console.WriteLine(result);
            }
        }

        private static long roadsAndLibraries(int n, int c_lib, int c_road, int[][] cities)
        {
            Graph g = new Graph(n);

            foreach (var e in cities)
            {
                g.addEdge(e[0] - 1, e[1] - 1);
            }

            int result = g.getUnconnectedNodes();

            //foreach (var e in damaged)
            //{
            //    g.addEdge(e[0] - 1, e[1] - 1);
            //}
            //int dam = g.getUnconnectedNodes();
            //if (dam != 0)
            //    return -1;
            return result;
        }
    }
}
