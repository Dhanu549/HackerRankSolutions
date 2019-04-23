using System;

namespace HackerRank
{
    public class DoublyLinkedListNode
    {
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev;

        public DoublyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
            this.prev = null;
        }
    }

    public class DoublyLinkedList
    {
        public DoublyLinkedListNode head;
        public DoublyLinkedListNode tail;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
                node.prev = this.tail;
            }

            this.tail = node;
        }
    }

    public class SortedDoublyLinkedList
    {
        static void PrintDoublyLinkedList(DoublyLinkedListNode node, string sep)
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

        static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode head, int data)
        {
            DoublyLinkedListNode current = head, previous = null;
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(data);

            while(current?.data < data)
            {
                previous = current;
                current = current.next;
            }

            newNode.next = current;
            newNode.prev = previous;
            if (previous != null)
                previous.next = newNode;
            else
                return newNode;
            if (current != null)
                current.prev = newNode;

            return head;
        }

        static DoublyLinkedListNode reverse(DoublyLinkedListNode head)
        {
            DoublyLinkedListNode current = head, previous = null;

            while (current != null)
            {
                previous = current;
                current = current.next;

                previous.next = previous.prev;
                previous.prev = current;
            }
            
            return previous;
        }

        public static void Execute()
        {

            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                DoublyLinkedList llist = new DoublyLinkedList();

                int llistCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < llistCount; i++)
                {
                    int llistItem = Convert.ToInt32(Console.ReadLine());
                    llist.InsertNode(llistItem);
                }

                int data = Convert.ToInt32(Console.ReadLine());

                DoublyLinkedListNode llist1 = sortedInsert(llist.head, data);

                PrintDoublyLinkedList(llist1, " ");
                Console.WriteLine();
            }
        }
    }
}
