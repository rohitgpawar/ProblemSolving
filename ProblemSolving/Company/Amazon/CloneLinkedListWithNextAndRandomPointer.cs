/*
 
Given a linked with next pointer and random pointer. Clone the linked List.

You are given a Double Link List with one pointer of each node pointing to the next node just like in a single link list. 
The second pointer however CAN point to any node in the list and not just the previous node. Now write a program in O(n) time to duplicate this list. 
That is, write a program which will create a copy of this list.

 */

using System.Collections;
using System.Collections.Generic;

namespace ProblemSolving
{
    public class CloneLinkedListWithNextAndRandomPointer
    {
        public static void CloneLinkedListWithNextAndRandomPointerMain()
        {
            DoublyLinkedList ll = new DoublyLinkedList();
            DoublyLinkedListNode node1 = new DoublyLinkedListNode(1);
            DoublyLinkedListNode node2 = new DoublyLinkedListNode(2);
            DoublyLinkedListNode node3 = new DoublyLinkedListNode(3);
            DoublyLinkedListNode node4 = new DoublyLinkedListNode(4);
            node1.next = node2;
            node1.prev = node3;
            node2.next = node3;
            node2.prev = node4;
            node3.next = node4;
            node3.prev = node1;
            node4.prev = node2;
            ll.AddNode(node1);
            ll.PrintLL();
            DoublyLinkedList copyLL = new DoublyLinkedList();

            CloneLinkedList(ll, copyLL);
            copyLL.PrintLL();
            copyLL = new DoublyLinkedList();

            CloneLinkedListInConstantSpace(ll, copyLL);
            copyLL.PrintLL();
        }

        /// <summary>
        /// Use Hashtable to store the copyList object as we create while going next on originalLL. Use hashtable to restore prev(random) pointer
        /// Time O(n) Space O(n)
        /// </summary>
        /// <param name="linkedList"></param>
        /// <param name="copyList"></param>
        public static void CloneLinkedList(DoublyLinkedList linkedList, DoublyLinkedList copyList)
        {
            Hashtable linkedObj = new Hashtable();
            DoublyLinkedListNode llNode = linkedList.Head;
            DoublyLinkedListNode copyPrevNode =new DoublyLinkedListNode(0);
            while (llNode!=null)
            {
                DoublyLinkedListNode copyNode = new DoublyLinkedListNode(llNode.data);
                linkedObj.Add(copyNode.data, copyNode);
                if(copyList.Head == null)
                {//Add first Element
                    copyPrevNode = copyNode;
                    //copyPrevNode.next =
                    copyList.AddNode(copyNode);
                }
                else
                {//
                    copyPrevNode.next = copyNode;
                    copyPrevNode = copyNode;
                }
                llNode = llNode.next;
            }
            llNode = linkedList.Head;
            DoublyLinkedListNode copyLlNode = copyList.Head;

            while (llNode!=null && copyLlNode!=null)
            {
                DoublyLinkedListNode copyNode = (DoublyLinkedListNode)linkedObj[llNode.prev.data];
                copyLlNode.prev = copyNode;
                llNode = llNode.next;
                copyLlNode = copyLlNode.next;
                //copyList.AddBefore(llNode, copyNode);
            }
        }

        /// <summary>
        /// Create copyLL node in between of OriginalLL node and iterate two steps to set the right prev(random) path.
        /// Time O(n) Space O(1)
        /// </summary>
        /// <param name="originalLL"></param>
        /// <param name="copyLL"></param>
        public static void CloneLinkedListInConstantSpace(DoublyLinkedList originalLL, DoublyLinkedList copyLL)
        {
            DoublyLinkedListNode originalLLNode = originalLL.Head;
            DoublyLinkedListNode copyLLNode = null;
            while(originalLLNode != null)
            {//Iterate original LL
                copyLLNode = new DoublyLinkedListNode(originalLLNode.data*-1);
                copyLLNode.next = originalLLNode.next;
                originalLLNode.next = copyLLNode;
                originalLLNode = originalLLNode.next.next; // Move 2 steps ahead
            }
            //Each Copy Node is added between each original Node
            originalLLNode = originalLL.Head;
            while (originalLLNode != null)
            {//Set prev (Random) node value and seperate two lists.
                //Original next is Copy LLNode so use that to update prev of Copy LL node
                originalLLNode.next.prev = originalLLNode.prev.next;
                originalLLNode = originalLLNode.next.next;
            }
            originalLLNode = originalLL.Head;
            //Set CopyList Head
            copyLL.Head = originalLLNode.next;
            copyLLNode = copyLL.Head;
            while (originalLLNode != null)
            {//Seperate Original and CopyList
                originalLLNode.next = originalLLNode.next.next;
                if (copyLLNode.next != null)
                    copyLLNode.next = copyLLNode.next.next;
                else
                    copyLLNode.next = null;
                originalLLNode = originalLLNode.next;
                copyLLNode = copyLLNode.next;
            }

        }
    }
}
