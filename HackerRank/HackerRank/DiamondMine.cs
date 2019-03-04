using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public class DiamondMine
    {
        public static void Execute()
        {
            long res = 0;
            int matRows = Convert.ToInt32(Console.ReadLine().Trim());
            int matColumns = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> mat = new List<List<int>>();

            for (int i = 0; i < matRows; i++)
            {
                mat.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matTemp => Convert.ToInt32(matTemp)).ToList());
            }
            n = matRows;
            solve();            
            res = res + ans[n - 1,n - 1];
            update();
            init();
            solve();
            res = res + ans[n - 1,n - 1];

            //int result = collectMax(mat);

            Console.WriteLine(res);
        }

        public static int collectMax(List<List<int>> mat)
        {
            int n = mat.Count();
            int count = 0;
            if (mat[0][0] == -1 || mat[n - 1][n - 1] == -1)
            {
                return 0;
            }
            if (mat[0][0] == 1)
            {
                count++;
                mat[0][0] = 0;
            }
            for (int i = 0; i < n - 1; )
            {
                for (int j = 0; j < n - 1; )
                {
                    if (j + 1 < n && mat[i][j + 1] == -1 && i + 1 < n && mat[i + 1][j] == -1)
                    {
                        return 0;
                    }
                    else if (j + 1 < n && mat[i][j + 1] == -1 && i + 1 < n && mat[i + 1][j] >= 0)
                    {
                        if (mat[i + 1][j] == 1)
                            count++;
                        mat[i + 1][j] = 0;
                        i++;
                    }
                    else if (i + 1 < n && mat[i + 1][j] == -1 && j + 1 < n && mat[i][j + 1] >= 0)
                    {
                        if (mat[i][j + 1] == 1)
                            count++;
                        mat[i][j + 1] = 0;
                        j++;
                    }
                    else if (i + 1 < n && mat[i + 1][j] == 0 && j + 1 < n && mat[i][j + 1] == 1)
                    {
                        count++;
                        mat[i][j + 1] = 0;
                        j++;
                    }
                    else if (j + 1 < n && mat[i][j + 1] == 0 && i + 1 < n && mat[i + 1][j] == 1)
                    {
                        count++;
                        mat[i + 1][j] = 0;
                        i++;
                    }
                    else if (j + 1 < n && mat[i][j + 1] == 0 && i + 1 < n && mat[i + 1][j] == 0)
                    {
                        count++;
                        j++;
                    }
                    else if (j + 1 < n && mat[i][j + 1] == 1 && i + 1 < n && mat[i + 1][j] == 1)
                    {
                        count++;
                        mat[i][j + 1] = 0;
                        j++;
                    }
                }
            }
            for (int i = n - 1; i >= 0; )
            {
                for (int j = n - 1; j >= 0; )
                {
                    if (j - 1 >= 0 && mat[i][j - 1] == -1 && i - 1 >= 0 && mat[i - 1][j] == -1)
                    {
                        return 0;
                    }
                    else if (j - 1 >= 0 && mat[i][j - 1] == -1 && i - 1 >= 0 && mat[i - 1][j] >= 0)
                    {
                        if (mat[i - 1][j] == 1)
                            count++;
                        mat[i - 1][j] = 0;
                        i--;
                    }
                    else if (i - 1 >= 0 && mat[i - 1][j] == -1 && j - 1 >= 0 && mat[i][j - 1] >= 0)
                    {
                        if (mat[i][j - 1] == 1)
                            count++;
                        mat[i][j - 1] = 0;
                        j--;
                    }
                    else if (i - 1 >= 0 && mat[i - 1][j] == 0 && j - 1 >= 0 && mat[i][j - 1] == 1)
                    {
                        count++;
                        mat[i][j - 1] = 0;
                        j--;
                    }
                    else if (j - 1 >= 0 && mat[i][j - 1] == 0 && i - 1 >= 0 && mat[i - 1][j] == 1)
                    {
                        count++;
                        mat[i - 1][j] = 0;
                        i--;
                    }
                    else if (j - 1 >= 0 && mat[i][j - 1] == 0 && i - 1 >= 0 && mat[i - 1][j] == 0)
                    {
                        count++;
                        j--;
                    }
                    else if (j - 1 >= 0 && mat[i][j - 1] == 1 && i - 1 >= 0 && mat[i - 1][j] == 1)
                    {
                        count++;
                        mat[i][j - 1] = 0;
                        j--;
                    }
                }
            }
            return count;
        }

        static long n;
        static long[,] d = new long[1000,1000];
        static long[,] ans = new long[1000, 1000];
        static (long, long)[,] prev = new (long, long)[1000, 1000];

        public static void solve()
        {
            long i, j;
            if (d[0,0] != -1)
            {
                ans[0,0] = d[0,0];
                prev[0,0] = (-1, -1);
            }
            for (i = 1; i < n; i++)
            {
                if (d[0,i] == -1)
                    break;
                ans[0,i] = ans[0,i - 1] + d[0,i];
                prev[0,i] = (0, i - 1);
            }
            while (i < n)
            {
                ans[0,i] = -1;
                i++;
            }
            for (i = 1; i < n; i++)
            {
                if (d[i,0] == -1)
                    break;
                ans[i,0] = ans[i - 1,0] + d[i,0];
                prev[i,0] = (i - 1, 0);
            }
            while (i < n)
            {
                ans[i,0] = -1;
                i++;
            }
            for (i = 1; i < n; i++)
            {
                for (j = 1; j < n; j++)
                {
                    if (d[i,j] == -1)
                    {
                        ans[i,j] = -1;
                        continue;
                    }
                    if (ans[i - 1,j] > ans[i,j - 1])
                    {
                        ans[i,j] = ans[i - 1,j] + d[i,j];
                        prev[i,j] = (i - 1, j);
                    }
                    else
                    {
                        ans[i,j] = ans[i,j - 1] + d[i,j];
                        prev[i,j] = (i, j - 1);
                    }
                }
            }
        }
        static void update()
        {
            long i, j;
            (long,long) node;
            i = n - 1;
            j = n - 1;
            while (i != -1 && j != -1)
            {
                node = prev[i,j];
                d[i,j] = 0;
                i = node.Item1;
                j = node.Item2;
            }
        }
        static void init()
        {
            long i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    ans[i,j] = 0;
                }
            }
        }        
    }
}
