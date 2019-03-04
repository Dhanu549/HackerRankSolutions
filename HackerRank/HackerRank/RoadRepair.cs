using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static class RoadRepair
    {
        public static void Execute()
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());

            int m = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> functional = new List<List<int>>();

            for (int i = 0; i < m; i++)
            {
                functional.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(functionalTemp => Convert.ToInt32(functionalTemp)).ToList());
            }

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> damaged = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                damaged.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(damagedTemp => Convert.ToInt32(damagedTemp)).ToList());
            }

            int result = solve(t, functional, damaged);

            Console.WriteLine(result);

        }

        public static int solve(int t, List<List<int>> functional, List<List<int>> damaged)
        {
            Graph g = new Graph(t); 

            foreach(var e in functional)
            {
                g.addEdge(e[0] - 1 , e[1] - 1);
            }

            int result = g.getUnconnectedNodes();

            foreach (var e in damaged)
            {
                g.addEdge(e[0] - 1, e[1] - 1);
            }
            int dam = g.getUnconnectedNodes();
            if (dam != 0)
                return -1;
            return result;
        }
    }
   
    public class Graph
    {
        int V;
        List<int>[] adjListArray;

        public Graph(int V)
        {
            this.V = V;
            adjListArray = new List<int>[V];

            for (int i = 0; i < V; i++)
            {
                adjListArray[i] = new List<int>();
            }
        }

        public void addEdge(int src, int dest)
        {
            adjListArray[src].Add(dest);
            adjListArray[dest].Add(src);
        }

        public void DFSUtil(int v, bool[] visited)
        {
            visited[v] = true;
            foreach (int x in adjListArray[v])
            {
                if (!visited[x])
                    DFSUtil(x, visited);
            }
        }

        public int getUnconnectedNodes()
        {
            int c = -1;
            bool[] visited = new bool[V];
            for (int v = 0; v < V; ++v)
            {
                if (!visited[v])
                {
                    DFSUtil(v, visited);
                    c++;
                }
            }
            c += visited.Count(x => !x);
            return c;
        }
    }
}
