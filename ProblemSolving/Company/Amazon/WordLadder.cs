/*
 
 Given a dictionary, and two words ‘start’ and ‘target’ (both of same length). Find length of the smallest chain from ‘start’ to ‘target’ if it exists, such that adjacent words in the chain only differ by one character and each word in the chain is a valid word i.e., it exists in the dictionary. It may be assumed that the ‘target’ word exists in dictionary and length of all dictionary words is same.

Example:

Input:  Dictionary = {POON, PLEE, SAME, POIE, PLEA, PLIE, POIN}
             start = TOON
             target = PLEA
Output: 7
Explanation: TOON - POON - POIN - POIE - PLIE - PLEE - PLEA
 */


using System;
using System.Collections.Generic;

namespace ProblemSolving
{
    class WordLadder
    {

        public static void WordLadderMain()
        {
            HashSet<string> words = new HashSet<string> { "POON", "PLEE", "SAME", "POIE", "PLEA", "PLIE", "POIN" };
            string start = "TOON";
            string end = "PLEA";
            int length= FindTranformationLength(words, start, end);
        }
        
        /// <summary>
        /// Check if the source can be tranformed to target. Only 1 char change allowed
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsValidTransform(string source, string target)
        {
            int count = 0;
            if (source.Length != target.Length)
                return false;
            for (int position = 0; position < source.Length; position++)
            {
                if (source[position] != target[position])
                {//difference
                    count++;
                }
                if (count > 1)
                {//More than 1 difference
                    return false;
                }
            }
            return true;

        }

        /// <summary>
        /// Helper class to store string and length
        /// </summary>
        public class Path
        {
            public string currentPath;
            public int length;
            public Path(string path, int len)
            {
                currentPath = path;
                length = len;
            }
        }

        /// <summary>
        /// Computes length from start to end using BFS. add all transformable items to queue and keep iterating until we reach destination
        /// </summary>
        /// <param name="words"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int FindTranformationLength(HashSet<string> words, string start, string end)
        {
            Queue<Path> pathQ = new Queue<Path>();
            HashSet<string> visited = new HashSet<string>();
            pathQ.Enqueue(new Path(start, 1));

            while (pathQ.Count > 0)
            {
                Path currentPath = pathQ.Dequeue();
                foreach (String word in words)
                {//Iterate over all the words
                    if (!visited.Contains(word) && IsValidTransform(currentPath.currentPath, word))
                    {
                        if (word.Equals(end))
                            return currentPath.length + 1;
                        pathQ.Enqueue(new Path(word, currentPath.length + 1));
                        visited.Add(word);
                    }
                }
            }
            return 0;
        }
    }

}
