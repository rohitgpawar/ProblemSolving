
using System;

namespace ProblemSolving
{
    public class LinkedListNode
    {
        public LinkedListNode next = null;
        public int data;
        public LinkedListNode(int d)
        {
            data = d;
        }
    }

    public class LinkedList
    {
        private LinkedListNode head;
        public LinkedListNode Head
        {
            get { return head; }
            set { head = value; }
        }
        public LinkedListNode AddNode(LinkedListNode newNode)
        {
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                LinkedListNode currentNode = head;
                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }
                currentNode.next = newNode;
            }
            return head;
        }

        public LinkedListNode DeleteNode(LinkedListNode deleteNode)
        {
            if (head != null && head.data == deleteNode.data)
            {
                head = null;
            }
            else
            {
                LinkedListNode currentNode = head;
                while (currentNode != null)
                {
                    if (currentNode.next.data == deleteNode.data)
                    {
                        currentNode.next = currentNode.next.next;
                        break;
                    }
                    else
                    currentNode = currentNode.next;
                }
            }
            return head;
        }

        public void PrintLL()
        {
            LinkedListNode currentNode = head;
            while (currentNode != null)
            {
                Console.Write(currentNode.data + "   ->   ");
                currentNode = currentNode.next;
            }
            Console.WriteLine();
        }
    } 
}
