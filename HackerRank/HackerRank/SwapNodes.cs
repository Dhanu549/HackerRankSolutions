using System;
using System.Collections.Generic;
using System.Linq;

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
            List<int[]> res = new List<int[]>();
            
            BinaryTree tree = new BinaryTree();            
            BinaryTreeNode node = tree.convertToBinaryTree(indexes);

            foreach (int q in queries)
            {
                tree.swapAtLevelMupltiples(tree.root, q);
                List<int> l = new List<int>();
                res.Add(tree.inorderTraversal(tree.root, l).ToArray());
            }

            return res.ToArray();
        }
    }
   
    public class BinaryTreeNode
    {
        public int data;
        public int level;
        public BinaryTreeNode left, right = null;
        
        public BinaryTreeNode(int data, int level)
        {
            this.data = data;
            this.level = level;
            left = right = null;
        }
    }

    public class BinaryTree
    {        
        public BinaryTreeNode root;
        
        public BinaryTreeNode convertToBinaryTree(int[][] indexes)
        {
            Queue<BinaryTreeNode> q =
                        new Queue<BinaryTreeNode>();

            int level = 1;
            root = new BinaryTreeNode(1, level);
            q.Enqueue(root);

            foreach (var ind in indexes)
            {
                BinaryTreeNode parent = q.Dequeue();
                BinaryTreeNode leftChild = null, rightChild = null;

                if (ind[0] != -1)
                {
                    leftChild = new BinaryTreeNode(ind[0], parent.level + 1);
                    q.Enqueue(leftChild);
                }
                if (ind[1] != -1)
                {
                    rightChild = new BinaryTreeNode(ind[1], parent.level + 1);
                    q.Enqueue(rightChild);
                }
                
                parent.left = leftChild;
                parent.right = rightChild;
            }
            
            return root;
        }

        public void swapAtLevelMupltiples(BinaryTreeNode node, int swapLevel)
        {
            if (node == null)
                return;

            if(node.level % swapLevel == 0)
            {
                var temp = node.left;
                node.left = node.right;
                node.right = temp;
            }
            swapAtLevelMupltiples(node.left, swapLevel);
            swapAtLevelMupltiples(node.right, swapLevel);
        }

        public List<int> inorderTraversal(BinaryTreeNode node, List<int> l)
        {            
            if (node != null)
            {
                inorderTraversal(node.left, l);
                l.Add(node.data);
                inorderTraversal(node.right, l);
            }
            return l;
        }
    }
}
