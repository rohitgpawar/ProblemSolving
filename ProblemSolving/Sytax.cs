﻿
using System;
using System.Collections;
using System.Collections.Generic;

/*
 *
 // Array *************************************
    Array of Arrays (Jagged Array) *******
        int[][] jagged = new int[3][];
        jagged[0] = new int[4] {  1,  2,  3,  4 }; 
        jagged[1] = new int[2] { 11, 12 }; 

    //Jagged Array
        string[,] itemAssociation = new string[10,10];
        int rows = itemAssociation.GetLength(0);
        int cols = itemAssociation.GetLength(1);
        itmAss[0,0] = "Item1";
        itmAss[0, 0] = "Item2";

// Stack ***********************************
            Stack<int> stack = new Stack<int>();
            stack.Push(3);
            int peek = stack.Peek();
            stack.Pop();

 // Queue *************************************
            Queue<int> queue = new Queue<int>();
            queue.Peek();
            queue.Enqueue(3);
            queue.Dequeue();

//Hashtable **************************************
        Hashtable hashtable = new Hashtable();
        hashtable.Add("txt", "notepad.exe");
        hashtable["txt"] = "New";
        hashtable.ContainsKey("");
        foreach (DictionaryEntry de in hashtable)
        {
                //de.Key
                //de.Value
        }
 
//Dictionary***************************************     
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("txt", "notepad.exe");
        dictionary["doc"] = "winword.exe";
        string value = "";
        if (dictionary.TryGetValue("tif", out value))
        {
            Console.WriteLine("For key = \"tif\", value = {0}.", value);
        }
        if (!dictionary.ContainsKey("ht"))
        {
            dictionary.Add("ht", "hypertrm.exe");
        }
        foreach (KeyValuePair<string, string> kvp in dictionary)
        {
            Console.WriteLine("Key = {0}, Value = {1}",kvp.Key, kvp.Value);
        }

 //HashSet*******************************
        HashSet<int> evenNumbers = new HashSet<int>();
        evenNumbers.Add(1 * 2);
        HashSet<int> numbers = new HashSet<int>(evenNumbers);
        numbers.UnionWith(oddNumbers);
        evenNumbers.Contains(2);

     */
/*
 Absoulte or Modulus of number |-1| = 1
 System.Math.Abs();
     */
namespace ProblemSolving
{
    class Sytax
    {
        public Sytax()
        {
            int[] a = new int[2];
            int j = a.Length;
            int t = Int32.MaxValue;
            // Stack ***********************************
            Stack<int> stack = new Stack<int>();
            stack.Push(3);
            int peek = stack.Peek();
            stack.Pop();

            // Queue *************************************
            Queue<int> queue = new Queue<int>();
            queue.Peek();
            queue.Enqueue(3);
            queue.Dequeue();
            //queue.Count;
            //Hashtable**************************************** 

            Hashtable openWith = new Hashtable();
            // Add some elements to the hash table. Keys cannot be duplicate.
            openWith.Add("txt", "notepad.exe");
            openWith["txt"] = "New";
            openWith.ContainsKey("");
            foreach (DictionaryEntry de in openWith)
            {
                //de.Key
                //de.Value
            }
            HashSet<int> value1= (HashSet < int > )openWith["txt"];
            // When you use foreach to enumerate hash table elements, the elements are retrieved as KeyValuePair objects.
            foreach (DictionaryEntry de in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }

            // To get the values alone, use the Values property.
            ICollection valueColl = openWith.Values;
            
            // The elements of the ValueCollection are strongly typed with the type that was specified for hash table values.


            //Dictionary***************************************

            // Create a new dictionary of strings, with string keys.
            //
            Dictionary<string, string> openWithD = new Dictionary<string, string>();
            
            // Add some elements to the dictionary. There are no duplicate keys.
            openWithD.Add("txt", "notepad.exe");
            // If a key does not exist, setting the indexer for that key
            // adds a new key/value pair.
            openWithD["doc"] = "winword.exe";

            // When a program often has to try keys that turn out not to
            // be in the dictionary, TryGetValue can be a more efficient 
            // way to retrieve values.
            string value = "";
            if (openWithD.TryGetValue("tif", out value))
            {
                Console.WriteLine("For key = \"tif\", value = {0}.", value);
            }
            else
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            // ContainsKey can be used to test keys before inserting 
            // them.
            if (!openWithD.ContainsKey("ht"))
            {
                openWithD.Add("ht", "hypertrm.exe");
                Console.WriteLine("Value added for key = \"ht\": {0}",
                    openWithD["ht"]);
            }

            // When you use foreach to enumerate dictionary elements,
            // the elements are retrieved as KeyValuePair objects.
            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }


            //HashSet**********************************************

            HashSet<int> evenNumbers = new HashSet<int>();
            HashSet<int> oddNumbers = new HashSet<int>(evenNumbers);
            HashSet<int> oddNumbersC = new HashSet<int>();
            oddNumbersC.Add('c');
            //oddNumbersC.IntersectWith(IEnumerable<char>)
            evenNumbers.Add(1 * 2);
            evenNumbers.Add(1 * 2 + 1);
            evenNumbers.Contains(2);
            HashSet<int> numbers = new HashSet<int>(evenNumbers);
            Console.WriteLine("numbers UnionWith oddNumbers...");
            numbers.UnionWith(oddNumbers);
            //int i =evenNumbers.Count;
            //numbers.IntersectWith()
            //numbers.Remove(1);
            foreach (int i in evenNumbers)
            {

            }

            SortedList<int, int> sortedList = new SortedList<int, int>();
            sortedList.Capacity = 2;
            sortedList.Add(1, 1);
            sortedList.Add(2, 2);
            sortedList.Add(3, 3);

        }
    }
}
