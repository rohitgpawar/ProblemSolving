/*
 Check if a string is permutation of a palindrome.
 */
namespace ProblemSolving
{
    public class PalindromePermutation
    {
        public static bool CheckPalindromePermutation(string inputString)
        {
            bool[] isOddCharachter = new bool[128];
            int oddCharCount=0;
            foreach (char chr in inputString.ToLower())
            {
                if (chr == ' ')
                {
                    continue;
                }
                isOddCharachter[chr] = !isOddCharachter[chr];
                if (isOddCharachter[chr])
                {
                    oddCharCount++;
                }
                else
                {
                    oddCharCount--;
                }
            }
            if (oddCharCount < 2)
                return true;
            return false;
        }
    }
}
