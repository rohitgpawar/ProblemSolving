/*
 Remove duplicates from given LinkedList
 */
using System.Collections.Generic;

namespace ProblemSolving
{
    public class RemoveDuplicates
    {
        public static void RemoveDuplicatefromLL()
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddNode(new LinkedListNode(10));
            linkedList.AddNode(new LinkedListNode(100));
            linkedList.AddNode(new LinkedListNode(12));
            linkedList.AddNode(new LinkedListNode(10));
            linkedList.AddNode(new LinkedListNode(100));
            linkedList.AddNode(new LinkedListNode(80));

            HashSet<int> hashSet = new HashSet<int>();
            LinkedListNode currentNode = linkedList.Head;
            LinkedListNode previousNode = null;
            linkedList.PrintLL();
            while (currentNode != null)
            {
                if (hashSet.Contains(currentNode.data))
                {
                    previousNode.next = currentNode.next;
                }
                else
                {
                    hashSet.Add(currentNode.data);
                    previousNode = currentNode;
                }
                currentNode = currentNode.next;
            }
            linkedList.PrintLL();
        }
    }
}
