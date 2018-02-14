/*
 
 Merge two sorted lists (in-place)
3.2
Given two sorted lists, merge them so as to produce a combined sorted list (without using extra space).

Examples:

Input : head1: 5->7->9
        head2: 4->6->8 
Output : 4->5->6->7->8->9

Input : head1: 1->3->5->7
        head2: 2->4
Output : 1->2->3->4->5->7
 */

using System.Collections.Generic;

namespace ProblemSolving
{
    public class MergeTwoLinkedList
    {
        public static void MergeTwoLinkedListMain()
        {
            LinkedList linkedList1 = new LinkedList();
            linkedList1.AddNode(new LinkedListNode(1));
            linkedList1.AddNode(new LinkedListNode(3));
            linkedList1.AddNode(new LinkedListNode(5));
            linkedList1.AddNode(new LinkedListNode(7));

            LinkedList linkedList2 = new LinkedList();
            linkedList2.AddNode(new LinkedListNode(2));
            linkedList2.AddNode(new LinkedListNode(4));
            //linkedList2.AddNode(new LinkedListNode(8));

            MergeTwoLL(linkedList1, linkedList2);
            linkedList1.PrintLL();
        }

        /// <summary>
        /// Merge two LinkedList in place
        /// </summary>
        /// <param name="ll1"></param>
        /// <param name="ll2"></param>
        public static LinkedList MergeTwoLL(LinkedList ll1, LinkedList ll2)
        {
            LinkedList leftLL = (ll1.Head.data <= ll2.Head.data) ? ll1 : ll2;
            LinkedList rightLL = (ll1.Head.data > ll2.Head.data) ? ll1 : ll2;

            //Starting List which has first element as small value will be pointed by leftLL

            //Pointer to LeftLL current and next
            LinkedListNode current1 = leftLL.Head;
            LinkedListNode next1 = leftLL.Head.next;
            
            //Pointer to rightLL current and next
            LinkedListNode current2 = rightLL.Head;
            LinkedListNode next2 = rightLL.Head.next;

            while(next1 != null && next2 != null)
            {//While both the LL contain elements
                if (current1.data <= current2.data && current2.data < next1.data)
                {//Check if current 2 lies between current1 and next1 then do current1->current2->next1
                    //********* SET NEXT2 TO CURRENT2.NEXT
                    next2 = current2.next;
                    current1.next = current2;
                    current2 = current2.next;
                    current1.next.next = next1;
                    current1 = current1.next;
                }
                else
                {//current2 is not in between then increment current1 and next1;
                    if(next1.next != null)
                    {
                        current1 = current1.next;
                        next1 = next1.next;
                    }
                    else
                    {//leftL1 ends
                        next1.next = current2;
                        return leftLL;
                    }
                }
            }
            return leftLL;
        }
    }

    
}
