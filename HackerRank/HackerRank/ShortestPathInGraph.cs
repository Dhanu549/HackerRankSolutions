using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    static class ShortestPathInGraph
    {
        public static void Execute()
        {
            int[,] mat = {  { 1, 0, 0 },
                            { 1, 0, 0 },
                            { 1, 9, 1 } };

            int size = mat.GetLength(0);

            int x = 0, y = 0;
            for(int i=0;i<size;i++)
                for(int j=0;j<size; j++)
                    if(mat[i,j]==9)
                    {
                        x = i;
                        y = j;
                        break;
                    }

            Console.WriteLine(shortestPath(mat, (0, 0), (x, y), size));
            Console.ReadLine();
        }

        static int shortestPath(int[,] mat, (int, int) u, (int, int) v, int n)
        {
            // visited[n] for keeping track of visited nodes
            bool[,] visited = new bool[n, n];

            // Initialize distances as 0
            int[,] distance = new int[n, n];

            // queue to do BFS.
            Queue<(int, int)> Q = new Queue<(int, int)>();
            distance[u.Item1, u.Item2] = 0;

            Q.Enqueue(u);
            visited[u.Item1, u.Item2] = true;
            while (Q.Count > 0)
            {
                var x = Q.Dequeue();
                int i = x.Item1;
                int j = x.Item2;

                //break code
                if (mat[i, j] == 9)
                    break;

                if (i + 1 < n && mat[i + 1, j] != 0 && !visited[i + 1, j])
                {
                    distance[i + 1, j] = distance[i, j] + 1;
                    Q.Enqueue((i + 1, j));
                    visited[i + 1, j] = true;
                }
                if (j + 1 < n && mat[i, j + 1] != 0 && !visited[i, j + 1])
                {
                    distance[i, j + 1] = distance[i, j] + 1;
                    Q.Enqueue((i, j + 1));
                    visited[i, j + 1] = true;
                }
                if (i - 1 >= 0 && mat[i - 1, j] != 0 && !visited[i - 1, j])
                {
                    distance[i - 1, j] = distance[i, j] + 1;
                    Q.Enqueue((i - 1, j));
                    visited[i - 1, j] = true;
                }
                if (j - 1 >= 0 && mat[i, j - 1] != 0 && !visited[i, j - 1])
                {
                    distance[i, j - 1] = distance[i, j] + 1;
                    Q.Enqueue((i, j - 1));
                    visited[i, j - 1] = true;
                }
            }
            return distance[v.Item1, v.Item2];
        }

        //static int INF = 99999;

        //static int findMinimumSteps(int[,] mat, int x, int y, int n)
        //{
        //    // dist[][] will be the output matrix that  
        //    // will finally have the shortest  
        //    // distances between every pair of numbers  
        //    int i, j, k;
        //    int[,] dist = new int[n, n];

        //    // Initially same as mat  
        //    for (i = 0; i < n; i++)
        //    {
        //        for (j = 0; j < n; j++)
        //        {
        //            if (mat[i, j] == 0)
        //                dist[i, j] = INF;
        //            else
        //                dist[i, j] = 1;

        //            //if (i == j)
        //            //    dist[i, j] = 1;
        //        }
        //    }
            
        //    for (k = 0; k < n; k++)
        //    {
        //        // Pick all numbers as source one by one  
        //        for (i = 0; i < n; i++)
        //        {
        //            // Pick all numbers as destination for the  
        //            // above picked source  
        //            for (j = 0; j < n; j++)
        //            {
        //                // If number k is on the shortest path from  
        //                // i to j, then update the value of dist[i][j]  
        //                if (dist[i, k] + dist[k, j] < dist[i, j])
        //                    dist[i, j] = dist[i, k] + dist[k, j];
        //            }
        //        }
        //    }

        //    // If no path  
        //    if (dist[x, y] < INF)
        //        return dist[x, y];
        //    else
        //        return -1;
        //}                
    }
}
