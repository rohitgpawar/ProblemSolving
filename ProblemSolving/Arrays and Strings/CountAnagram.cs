/*
 Find count of Anagram of string in given string
 find Anagram of needle in haystack
 Anagram means "rohit" "hirot" arranging of all characters in any order.
 */

using System.Collections.Generic;
using System.Linq;


namespace ProblemSolving
{
    public class CountAnagram
    {
        public static void CountAnagramMain()
        {
            getAnagramIndices("ababsbdbaafabsbdabfbdsbfaab", "aa");
        }

        public static List<int> getAnagramIndices(string haystack, string needle)
        {
            // WRITE YOUR CODE HERE
            int haystackPosition = 0;
            int needleLength = 0;
            int haystackLastPos = 0;
            List<int> anagramIndices = new List<int>();
            int[] needleSet = new int[256];
            foreach (char n in needle)
            {
                needleSet[n]++;
                needleLength++;
            }

            foreach (char h in haystack)
            {
                haystackLastPos = haystackPosition + needleLength;
                if (haystackLastPos <= haystack.Length)
                {
                    if (isAnagram(needleSet.ToArray(), haystack.Substring(haystackPosition, needleLength)))
                    {
                        anagramIndices.Add(haystackPosition);
                    }
                }
                haystackPosition++;
            }
            return anagramIndices;
        }

        public static bool isAnagram(int[] needleSet, string subHaystack)
        {

            foreach (char sub in subHaystack)
            {
                if (needleSet[sub] == 0)
                {
                    return false;
                }
                else
                {
                    needleSet[sub]--;
                }
            }
            for (int i = 0; i < 256; i++)
            {
                if (needleSet[i] > 0)
                    return false;
            }

            return true;
        }
    }
}
