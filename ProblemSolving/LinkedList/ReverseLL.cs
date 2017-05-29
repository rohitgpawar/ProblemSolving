/*
 Reverse a Linked List
 */

namespace ProblemSolving
{
    public class ReverseLL
    {
        public static void ReverseLinkedList()
        {
            LinkedList list = new LinkedList();
            list.AddNode(new LinkedListNode(1));
            list.AddNode(new LinkedListNode(2));
            list.AddNode(new LinkedListNode(3));
            list.AddNode(new LinkedListNode(4));
            list.AddNode(new LinkedListNode(5));

            LinkedList reverseList = new LinkedList();
            LinkedListNode head = list.Head;
            while (head != null)
            {
                LinkedListNode node = new LinkedListNode(head.data);
                node.next = reverseList.Head;
                reverseList.Head = node;
                head = head.next;
            }
            reverseList.PrintLL();
            
        }
    }
}
