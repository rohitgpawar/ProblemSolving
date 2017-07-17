/*
Cracking Coding Interviews. Array and Strings. 
Check if a string is permutation of a palindrome.
 */
namespace ProblemSolving
{
    public class PalindromePermutation
    {
        /*Count How many characters have odd count in the string. For that use bool array to toggle count of odd charachters. 
        check the odd count at the end if odd count is more than one then string permutation not palindrom*/
        public static bool CheckPalindromePermutation(string inputString)
        {//Bool array to store the isOdd value of each character in the string. Convert every character to lower case so we need only 128 characters to track.
            bool[] isOddCharacter = new bool[128];
            int oddCharCount=0;
            foreach (char chr in inputString.ToLower())
            {
                if (chr == ' ')
                {
                    continue;
                }
                isOddCharacter[chr] = !isOddCharacter[chr];//Toggle isOddCharacter value.
                if (isOddCharacter[chr])
                {//isOddCharacter is true means count is odd.
                    oddCharCount++;
                }
                else
                {//isOddCharacter is false means count is even.
                    oddCharCount--;
                }
            }
            if (oddCharCount < 2) //Id odd count is more than 1 then its not palindrome.
                return true;
            return false;
        }
    }
}
