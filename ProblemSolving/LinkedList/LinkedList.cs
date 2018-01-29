
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

    public class DoublyLinkedListNode
    {
        public DoublyLinkedListNode next = null;
        public DoublyLinkedListNode prev = null;
        public int data;
        public DoublyLinkedListNode(int d)
        {
            data = d;
        }
    }

    public class DoublyLinkedList
    {
        private DoublyLinkedListNode head;
        public DoublyLinkedListNode Head
        {
            get { return head; }
            set { head = value; }
        }
        public DoublyLinkedListNode AddNode(DoublyLinkedListNode newNode)
        {
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                DoublyLinkedListNode currentNode = head;
                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }
                currentNode.next = newNode;
            }
            return head;
        }

        //Not Implemented for Doubly
        public DoublyLinkedListNode DeleteNode(DoublyLinkedListNode deleteNode)
        {
            if (head != null && head.data == deleteNode.data)
            {
                head = null;
            }
            else
            {
                DoublyLinkedListNode currentNode = head;
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
            DoublyLinkedListNode currentNode = head;
            while (currentNode != null)
            {
                Console.Write(currentNode.data + "   ->   ");
                currentNode = currentNode.next;
            }
            Console.WriteLine();
        }
    }

}
