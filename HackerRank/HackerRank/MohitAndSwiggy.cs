using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public class MohitAndSwiggy
    {
        public static void Execute()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            List<List<int>> roads = new List<List<int>>();

            for (int i = 0; i < m; i++)
            {
                roads.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(roadsTemp => Convert.ToInt32(roadsTemp)).ToList());
            }

            int result = Solve(n, roads);

            Console.WriteLine(result);
        }

        private static int Solve(int n, List<List<int>> roads)
        {
            Graph2 graph = new Graph2(n + 1);
            foreach(var road in roads)
            {
                graph.addEdge(road[0], road[1], road[2]);
            }
            return graph.getShortestPath();
        }
    }

    public class Graph2
    {
        int V;
        List<Tuple<int,int>>[] adjListArray;
        int totalDistance = 0;

        public Graph2(int v)
        {
            V = v;
            adjListArray = new List<Tuple<int, int>>[V];
            for(int i=0;i<V;i++)
            {
                adjListArray[i] = new List<Tuple<int, int>>();
            }
        }

        public void addEdge(int u, int v, int distance)
        {
            adjListArray[u].Add(Tuple.Create(v, distance));
            adjListArray[v].Add(Tuple.Create(u, distance));
        }

        public void DFSUtil(int v, int distance, bool[] visited)
        {
            visited[v] = true;
            totalDistance += distance;
            foreach (var x in adjListArray[v])
            {
                if (!visited[x.Item1])
                    DFSUtil(x.Item1, x.Item2, visited);
            }
        }

        public int getShortestPath()
        {
            bool[] visited = new bool[V];

            DFSUtil(0, 0,visited);
            return totalDistance * 2;
        }
    }
}
