/*
 Partition a LL around a value x such that all nodes less than x comes before all nodes greater than or equal to x.
 eg: 3->5->8->5->10->2->1 [Partition =5]
 output: 3->1->2->10->5->5->8
 */
namespace ProblemSolving
{
    public class Partition
    {
        public static void PartitionLL(int partitionData)
        {
            LinkedList linkedList = new LinkedList();
            linkedList.AddNode(new LinkedListNode(3));
            linkedList.AddNode(new LinkedListNode(5));
            linkedList.AddNode(new LinkedListNode(8));
            linkedList.AddNode(new LinkedListNode(5));
            linkedList.AddNode(new LinkedListNode(10));
            linkedList.AddNode(new LinkedListNode(2));
            linkedList.AddNode(new LinkedListNode(1));
            linkedList.PrintLL();

            LinkedListNode currentNode = linkedList.Head;
            LinkedListNode smallerNode = linkedList.Head;
            LinkedListNode greaterNode = linkedList.Head;

            while (currentNode.data < partitionData)
            {
                smallerNode = currentNode;
                currentNode = currentNode.next;
            }
            while (currentNode.next != null)
            {
                if (currentNode.next.data < partitionData)
                {
                    LinkedListNode moveSmallerNode = currentNode.next;
                    currentNode.next = moveSmallerNode.next;
                    moveSmallerNode.next = smallerNode.next;
                    smallerNode.next = moveSmallerNode;
                    if (smallerNode.data == linkedList.Head.data)
                    {//Smaller node is Head
                        int nextData = moveSmallerNode.data;
                        smallerNode.next.data = smallerNode.data;
                        smallerNode.data = nextData;
                    }
                    else
                        smallerNode = moveSmallerNode;
                }
                else
                {
                    currentNode = currentNode.next;
                }
            }
            linkedList.PrintLL();

        }
    }
}
