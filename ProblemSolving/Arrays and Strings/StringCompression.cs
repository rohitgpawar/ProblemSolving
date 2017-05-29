/*
 Perform basic String compression. eg: aaabcc => a3b1c2. If compressed string is not smaller return original string.
 */
using System.Text;

namespace ProblemSolving
{
    public class StringCompression
    {
        public static string GetCompressedString(string inputString)
        {
            int index = 0;
            StringBuilder compresseString = new StringBuilder();
            while (index < inputString.Length)
            {
                int countChar = 1;
                while (index < inputString.Length - 1 && inputString[index] == inputString[index + 1])
                {
                    countChar++;
                    index++;
                }
                compresseString.Append(inputString[index].ToString() + countChar);
                index++;
            }
            if (compresseString.Length < inputString.Length)
                return compresseString.ToString();
            else
                return inputString;
        }
    }
}
