/*
 Longest Palindromic Subsequence | Set 1

As another example, if the given sequence is “BBABCBCAB”, then the output should be 7 as “BABCBAB” is the longest palindromic subseuqnce in it.
“BBBBB” and “BBCBB” are also palindromic subsequences of the given sequence, but not the longest ones.

 */

using System;

namespace ProblemSolving
{
    public class LongestSubsequencePalindrome
    {

        public static void LongestSubsequencePalindromeMain()
        {
            string text = "foggf";
            PrintLongestSubsequencePalindrome(text);
        }

        /// <summary>
        /// Computes subsequence palindrome using dynamic programming
        /// </summary>
        /// <param name="text"></param>
        public static void PrintLongestSubsequencePalindrome(string text)
        {
            //Array to store subsequence values using DP
            int[][] subsequenceDP = new int[text.Length][];
            for (int i = 0; i < text.Length; i++)
            {
                subsequenceDP[i] = new int[text.Length];
            }

            for (int i = 0; i < text.Length; i++)
            {//Mark subsequence palindrome length for 1 character as 1
                subsequenceDP[i][i] = 1;
            }

            for (int seqLength = 2; seqLength <= text.Length; seqLength++)
            {// length of subsequence
                for (int i = 0; i < text.Length - seqLength + 1; i++)
                {//
                    int j = i + seqLength - 1; // get last char of subsequence

                    //If i and j match then length depends on i+1 & j-1 length
                    if (text[i] == text[j] && seqLength == 2)
                    {//When sequence length is 2 then set value as 2
                        subsequenceDP[i][j] = 2;
                    }
                    else if (text[i] == text[j])
                    {//Both char match
                        subsequenceDP[i][j] = subsequenceDP[i + 1][j - 1] + 2;
                    }
                    else
                    {//If i and j do not match then length is Max of i,j-1 or i+1,j
                        subsequenceDP[i][j] = Math.Max(subsequenceDP[i][j - 1], subsequenceDP[i + 1][j]);
                    }

                }
            }

            Console.WriteLine("Longest Palindrome Subsequence is:"+subsequenceDP[0][text.Length-1]);

        }
    }

    
}
