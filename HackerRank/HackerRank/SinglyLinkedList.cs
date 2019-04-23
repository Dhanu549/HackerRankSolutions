using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    public class SinglylinkedListSolution
    {
        static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
        {
            while (node != null)
            {
                Console.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    Console.Write(sep);
                }
            }
        }

        static int findMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedListNode current1 = head1, current2 = head2;
                        
            //while(current1 != current2)
            //{
            //    if (current1.next == null)
            //        current1 = head2;
            //    else
            //        current1 = current1.next;

            //    if (current2.next == null)
            //        current2 = head1;
            //    else
            //        current2 = current2.next;
            //}

            //return current2.data;

            int len1 = 0, len2 = 0;
            while(current1!=null)
            {
                len1++;
                current1 = current1.next;                
            }
            while (current2 != null)
            {
                len2++;
                current2 = current2.next;                
            }

            current1 = head1;
            current2 = head2;
            while(len1 > len2)
            {
                current1 = current1.next;
                len1--;
            }
            while (len1 < len2)
            {
                current2 = current2.next;
                len2--;
            }
            while(current1 != null)
            {
                if (current1 == current2)
                    return current1.data;
                current1 = current1.next;
                current2 = current2.next;
            }
            return 0;
        }

        public static void Execute()
        {
            int tests = Convert.ToInt32(Console.ReadLine());

            for (int testsItr = 0; testsItr < tests; testsItr++)
            {
                int index = Convert.ToInt32(Console.ReadLine());

                SinglyLinkedList llist1 = new SinglyLinkedList();

                int llist1Count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llist1Count; i++)
                {
                    int llist1Item = Convert.ToInt32(Console.ReadLine());
                    llist1.InsertNode(llist1Item);
                }

                SinglyLinkedList llist2 = new SinglyLinkedList();

                int llist2Count = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llist2Count; i++)
                {
                    int llist2Item = Convert.ToInt32(Console.ReadLine());
                    llist2.InsertNode(llist2Item);
                }

                SinglyLinkedListNode ptr1 = llist1.head;
                SinglyLinkedListNode ptr2 = llist2.head;

                for (int i = 0; i < llist1Count; i++)
                {
                    if (i < index)
                    {
                        ptr1 = ptr1.next;
                    }
                }

                for (int i = 0; i < llist2Count; i++)
                {
                    if (i != llist2Count - 1)
                    {
                        ptr2 = ptr2.next;
                    }
                }

                ptr2.next = ptr1;

                int result = findMergeNode(llist1.head, llist2.head);

                Console.WriteLine(result);
            }
        }
    }
}
