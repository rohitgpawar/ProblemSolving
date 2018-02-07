/*
 Trie Data Sctructure Implementation
 Created for ProblemSolving\Company\Amazon\GroupByAnagrams
 */

using System.Collections.Generic;

namespace ProblemSolving
{
    /// <summary>
    /// Trie node class
    /// </summary>
    public class TrieNode
    {
        public bool isEnd;
        public List<int> Head;//List of integers to store indices for a perticular problem.
        public TrieNode[] childrens = new TrieNode[26];// Children to store 26 characters 'a' to 'z'

        public TrieNode()
        {
            isEnd = false;
            Head = new List<int>();
            for(int i=0;i<26;i++)
            {
                childrens[i] = null;
            }
        }
    }

    public class Trie
    {
        public static TrieNode Insert(TrieNode node, string word,int position, int index)
        {
            if(node == null)
            {// Create new node
                node = new TrieNode();
            }

            if(position < word.Length- 1)
            {//If note last position
                 
                int charPos = word[position] - 'a';
                node.childrens[charPos] = Insert(node.childrens[charPos], word, position + 1, index);
            }
            else
            {//It is last character in the word.
                if(node.isEnd)
                {//It has already marked end
                    node.Head.Add(index);
                }
                else
                {// First time reached this end
                    node.isEnd = true;
                    node.Head.Add(index);
                }
            }
            return node;
        }
    }
}
