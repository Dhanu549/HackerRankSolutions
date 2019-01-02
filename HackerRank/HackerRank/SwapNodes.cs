using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank
{
    public static class SwapNodes
    {
        public static void Execute()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[][] indexes = new int[n][];

            for (int indexesRowItr = 0; indexesRowItr < n; indexesRowItr++)
            {
                indexes[indexesRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), indexesTemp => Convert.ToInt32(indexesTemp));
            }

            int queriesCount = Convert.ToInt32(Console.ReadLine());

            int[] queries = new int[queriesCount];

            for (int queriesItr = 0; queriesItr < queriesCount; queriesItr++)
            {
                int queriesItem = Convert.ToInt32(Console.ReadLine());
                queries[queriesItr] = queriesItem;
            }

            int[][] result = swapNodes(indexes, queries);

            Console.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));
        }

        static int[][] swapNodes(int[][] indexes, int[] queries)
        {
            int[][] res = new int[queries.Length][];

            LinkedList<(int, int)> btree = new LinkedList<(int, int)>();
            
            LinkedListNode<(int, int)> root = new LinkedListNode<(int, int)>((1,1));
            btree.AddFirst(root);
            Stack<LinkedListNode<(int,int)>> s = new Stack<LinkedListNode<(int, int)>>();
            s.Push(root);
            int height = 1;
            foreach(var ind in indexes)
            {
                LinkedListNode<(int, int)> current = s.Pop();
                if (ind[0] != -1)
                {
                    s.Push(btree.AddBefore(current, (ind[0], current.Value.Item2 + 1)));
                    if (height < current.Value.Item2 + 1)
                        height = current.Value.Item2 + 1;
                }                    
                if (ind[1] != -1)
                {
                    s.Push(btree.AddAfter(current, (ind[1], current.Value.Item2 + 1)));
                    if (height < current.Value.Item2 + 1)
                        height = current.Value.Item2 + 1;
                }                    
            }

            foreach (int q in queries)
            {
                for (int i = q; i <= height; i += q)
                {

                }
            }

            return res;
        }
    }
}
