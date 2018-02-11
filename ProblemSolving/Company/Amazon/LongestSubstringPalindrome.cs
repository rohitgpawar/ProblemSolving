/*
 Longest Palindromic Substring 

Given a string, find the longest substring which is palindrome. 
For example, if the given string is “forgeeksskeegfor”, the output should be “geeksskeeg”.
 */
namespace ProblemSolving
{
    public class LongestSubstringPalindrome
    {
        public static void LongestSubstringPalindromeMain()
        {
            string text = "forgeeksskeegfor";
            PrintLongestSubstringPalindrome(text);
        }

        /// <summary>
        /// Print Longest Substring in Palindrome
        /// </summary>
        /// <param name="text"></param>
        public static void PrintLongestSubstringPalindrome(string text)
        {
            //To Store boolean value if substring exists
            bool[][] substringDP = new bool[text.Length][];
            for (int i = 0; i < text.Length; i++)
            {
                substringDP[i] = new bool[text.Length];
            }
            //Set value of single character as true
            for (int i = 0; i < text.Length; i++)
            {
                substringDP[i][i] = true;
            }

            int startIndex = 0; //Store start index
            int maxLength = 0; // Store max length of substring
            
            //Set substring of length = 2 as true 
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == text[i + 1])
                {//if consicutive characters match
                    substringDP[i][i + 1] = true;
                    startIndex = i;
                    maxLength = 2;
                }
            }

            for (int substringLength = 2; substringLength <= text.Length; substringLength++)
            {//Loop over substring length
                for(int substringStart=0; substringStart< text.Length - substringLength +1; substringStart++)
                {//find if the i and j qualify for substring;
                    int substringEnd = substringStart + substringLength - 1;

                    //Check if substringStart+1 and substringEnd-1 is a substring and current values match
                    if (substringDP[substringStart + 1][substringEnd - 1] && text[substringStart] == text[substringEnd])
                    {
                        substringDP[substringStart][substringEnd] = true;
                        if (substringLength > maxLength)
                        {
                            maxLength = substringLength;
                            startIndex = substringStart;
                        }
                    }
                }
            }
            //Print the max substring
            System.Console.WriteLine(text.Substring(startIndex,maxLength));
        }
    }
}
