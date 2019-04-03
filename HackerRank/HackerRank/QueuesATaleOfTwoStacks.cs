using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public class QueuesATaleOfTwoStacks
    {
        public static void Execute()
        {
            int q = Convert.ToInt32(Console.ReadLine());
            QueueWith2Stacks queue = new QueueWith2Stacks();
            for (int i=0;i<q;i++)
            {
                int[] operation = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
                switch(operation[0])
                {
                    case 1: queue.put(operation[1]);
                        break;
                    case 2: queue.pop();
                        break;
                    case 3: queue.peek();
                        break;
                }
            }
        }
    }

    public class QueueWith2Stacks
    {
        public Stack<int> stackOldestOnTop = new Stack<int>();
        public Stack<int> stackNewestOnTop = new Stack<int>();

        public void put(int val)
        {
            stackNewestOnTop.Push(val);
        }

        public void pop()
        {
            prepOld();
            stackOldestOnTop.Pop();
        }

        public void peek()
        {
            prepOld();
            Console.WriteLine(stackOldestOnTop.Peek());
        }

        private void prepOld()
        {
            if(stackOldestOnTop.Count == 0)
            {
                while(stackNewestOnTop.Count > 0)
                {
                    stackOldestOnTop.Push(stackNewestOnTop.Pop());
                }
            }            
        }

        //public void put(int val)
        //{
        //    while (stack1.Count > 0)
        //    {
        //        stack2.Push(stack1.Pop());
        //    }
        //    stack1.Push(val);
        //    while (stack2.Count > 0)
        //    {
        //        stack1.Push(stack2.Pop());
        //    }
        //}

        //public void pop()
        //{
        //    stack1.Pop();
        //}

        //public void peek()
        //{
        //    Console.WriteLine(stack1.Peek());
        //}
    }
}
