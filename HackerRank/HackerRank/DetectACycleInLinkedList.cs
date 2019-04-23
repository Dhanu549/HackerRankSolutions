namespace HackerRank
{
    public class Node
    {
        public int data;
        public Node next;
    }

    public class DetectACycleInLinkedList
    {
        static bool hasCycle(Node head)
        {
            if (head?.next == null)
                return false;
            Node slow = head, fast = head.next;

            while(slow != fast)
            {
                if (fast?.next == null)
                    return false;
                slow = slow.next;
                fast = fast.next.next;
            }
            return true;
        }
    }
}
