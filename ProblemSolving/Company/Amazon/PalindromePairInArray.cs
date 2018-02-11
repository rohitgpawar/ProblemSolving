/*
 Palindrome pair in an array of words (or strings)

Given a list of words, find if any of the two words can be joined to form a palindrome.

Examples:

Input  : list[] = {"geekf", "geeks", "or", 
                            "keeg", "abc", "bc"}
Output : Yes
There is a pair "geekf" and "keeg"

Input : list[] =  {"abc", "xyxcba", "geekst", "or",
                                      "keeg", "bc"}
Output : Yes
There is a pair "abc" and "xyxcba"

 *  */
//Use Trie
using System.Collections.Generic;
using System.Text;

namespace ProblemSolving
{
    public class PalindromePairInArray
    {
        public static void PalindromePairInArrayMain()
        {
            string[] words = new string[6] {"geekf", "geeks", "or",
                            "keeg", "abc", "bc" };// {"abc", "zyxcba", "xyxcba", "geekst", "keeg", "bc" };
            CheckPalindromPairInArray(words);
        }

        public static void CheckPalindromPairInArray(string[] words)
        {
            TrieNode root = null;
            //Insert reverse word in Trie Dataset
            for (int i = 0; i < words.Length; i++)
            {
                char[] reverseWord = words[i].ToCharArray();
                System.Array.Reverse(reverseWord);
                root = Trie.Insert(root, new string(reverseWord), 0, i);
            }
            //Check every word in Trie
            for (int i = 0; i < words.Length; i++)
            {
                int matchedIndex = FindPartialWord(root, words[i], 0);
                if(matchedIndex > 0)
                {//Palindrome found
                    System.Console.WriteLine(words[i]+" - "+words[matchedIndex]);
                }
            }
        }


        /// <summary>
        /// Return the position of character in word that matches in Trie
        /// </summary>
        /// <param name="node"></param>
        /// <param name="word"> word to be found</param>
        /// <param name="position">start position</param>
        /// <returns>Length of the charachters from the word found in Trie</returns>
        public static int FindPartialWord(TrieNode node, string word, int position)
        {
            if (position < word.Length)
            {//Get the character at position
                int trieChild = word[position] -'a';
                if (node.childrens[trieChild] != null)
                {//Child found recure to the child
                    return FindPartialWord(node.childrens[trieChild], word, position + 1);
                }
                else if (node.isEnd && CheckPalindrome(word.Substring(position)))
                {// Trie node has ended
                    //If remaining word is palindrome
                        return node.Head[0];
                }
                else
                {//Child not found return current position

                    return -1;
                }
            }
            else
            {//Reached wordLength so found all characters in Trie till now
                StringBuilder remainingword = new StringBuilder();
                return FindAllEndNodes(node, remainingword);
            }
        }

        public static int FindAllEndNodes(TrieNode node, StringBuilder remainingWord)
        {
            if(node==null)
            {//Return false
                return -1;
            }
            
            if (node.isEnd && CheckPalindrome(remainingWord.ToString()))
            {//Reached end
                // Return original position
                return node.Head[0];
            }
            else
            {
                for (int i = 0; i < 26; i++)
                {
                    if (node.childrens[i] != null)
                    {
                       return FindAllEndNodes(node.childrens[i], remainingWord.Append((char)(i+97)));
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Check if the word is Palindrome
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool CheckPalindrome(string word)
        {
            for (int i = 0; i < (word.Length / 2); i++)
            {
                if(!word[i].Equals(word[word.Length-1-i]))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
