/*
 
 Given a string of arrays “cat,dog,god,act”. Print all the anagrams which comes first in list.
eg.  output is cat ,act,dog and god. Means all the similar anagrams should be printed together and 
the next print should be the one which comes earlier in the list.
https://www.geeksforgeeks.org/given-a-sequence-of-words-print-all-anagrams-together/
hint : Trie approach was expected here.*/
/*
 Trie approach implemented
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProblemSolving
{
    public class GroupByAnagrams
    {
        public static void GroupByAnagramsMain()
        {
            //GetGroupByAnagram(new List<string>() { "cat", "dog", "tac", "god", "act" });
            GetGroupByAnagramTrieApproach(new List<string>() { "cat", "dog", "tac", "god", "act" });

        }

        /// <summary>
        /// Print Anagrams by group. Use Hashtable but it can have collisions.
        /// </summary>
        /// <param name="words"></param>
        public static void GetGroupByAnagram(List<string> words)
        {
            Hashtable anagramsByKey = new Hashtable();

            foreach (string word in words)
            {//Iterate on each word
                int wordAscii = 0;
                foreach (char ch in word)
                {
                    wordAscii += (int)ch;
                }
                if(!anagramsByKey.ContainsKey(wordAscii))
                {//Anagram not present
                    anagramsByKey[wordAscii] = new List<string>() { word };
                }
                else
                {//Anagram Present
                    List<string> anagramWords = (List<string>)anagramsByKey[wordAscii];
                    anagramWords.Add(word);
                }
            }
            
            foreach(string word in words)
            {
                int wordAscii = 0;
                foreach (char ch in word)
                {
                    wordAscii += (int)ch;
                }
                if (anagramsByKey.ContainsKey(wordAscii))
                {
                    List<string> anagramWords = (List<string>)anagramsByKey[wordAscii];
                    foreach (string anagram in anagramWords)
                    {//Print all anagrams together
                        System.Console.Write(anagram+" ");
                    }
                    //System.Console.WriteLine();
                    anagramsByKey.Remove(wordAscii);
                }
            }
        }

        /// <summary>
        /// Group the anagrams of words using Trie
        /// </summary>
        /// <param name="words"></param>
        public static void GetGroupByAnagramTrieApproach(List<string> words)
        {
            TrieNode root = null;
            for(int i=0;i<words.Count;i++)
            {//Insert sorted words in Trie
                string buffer = new string(words[i].ToCharArray());
                buffer = string.Concat(buffer.OrderBy(c => c));
                root = Trie.Insert(root, buffer, 0, i);
            }
            //Print Trie
            PrintTrieForAnalogs(root,words);

        }

        /// <summary>
        /// Print the indices stored at the head of End TrieNode
        /// </summary>
        /// <param name="root"></param>
        /// <param name="words"></param>
        private static void PrintTrieForAnalogs(TrieNode root, List<string> words)
        {
            if (root == null)
            {//Breaking condition
                return;
            }

            if (root.isEnd)
            {// This is the end TrieNode
                foreach (int index in root.Head)
                {//Indices of all analogs
                    Console.Write(words[index] + " ");
                }
                return;
            }
            else
            {//Not the end node so go deep
                for (int i = 0; i < 26; i++)
                {
                    PrintTrieForAnalogs(root.childrens[i], words);
                }
            }
        }
    }
}
