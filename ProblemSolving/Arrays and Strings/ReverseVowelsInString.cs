
using System;

namespace ProblemSolving
{
    public class ReverseVowelsInString
    {

        public static void ReverseVowels(string inputString)
        {
            char[] inputChars = inputString.ToCharArray();
            int lowerIndex = 0;
            int higherIndex = inputChars.Length - 1;
            while (lowerIndex < higherIndex)
            {
                if (IsVowel(inputChars[lowerIndex]) && IsVowel(inputChars[higherIndex]))
                {
                    if (inputChars[lowerIndex] != inputChars[higherIndex])
                    {
                        char temp = inputChars[lowerIndex];
                        inputChars[lowerIndex] = inputChars[higherIndex];
                        inputChars[higherIndex] = temp;
                    }
                    lowerIndex++;
                    higherIndex--;
                }
                else
                {
                    if (!IsVowel(inputChars[lowerIndex]))
                        lowerIndex++;
                    if (!IsVowel(inputChars[higherIndex]))
                        higherIndex--;
                }
            }

            Console.WriteLine(inputString);
            Console.WriteLine(string.Join("", inputChars));
        }

        private static bool IsVowel(char chk)
        {
            //chk = (char)chk.ToString().ToLower();
            if (chk == 'a' || chk == 'e' || chk == 'i' || chk == 'u' || chk == 'o')
            {
                return true;
            }

            return false;
        }
    }
}
