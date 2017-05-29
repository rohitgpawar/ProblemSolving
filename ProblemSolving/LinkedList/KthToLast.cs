/*
 Return Kth to the last of an LinkedList.
 */
using System;

namespace ProblemSolving
{
    public class KthToLast
    {
        public static void GetKthFromLastInLL(int position)
        {

            LinkedList linkedList = new LinkedList();
            linkedList.AddNode(new LinkedListNode(10));
            linkedList.AddNode(new LinkedListNode(100));
            linkedList.AddNode(new LinkedListNode(12));
            linkedList.AddNode(new LinkedListNode(10));
            linkedList.AddNode(new LinkedListNode(100));
            linkedList.AddNode(new LinkedListNode(80));
            linkedList.PrintLL();
            LinkedListNode runnerNode = linkedList.Head;
            LinkedListNode positionedNode = null;
            int count = 0;
            while (runnerNode != null)
            {
                runnerNode = runnerNode.next;
                if (count == position)
                {
                    positionedNode = linkedList.Head;
                }
                else if (positionedNode != null)
                {
                    positionedNode = positionedNode.next;
                }
                count++;
            }
            Console.WriteLine("{0} position from last is {1}", position, positionedNode != null ? positionedNode.data.ToString(): "null");
        }
    }
}
