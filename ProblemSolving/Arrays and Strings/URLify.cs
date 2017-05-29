using System.Text;

namespace ProblemSolving
{
    /*
     *  URLify the given string. Replace multiple spaces with %20.
        eg: "Hi    This   is   Rohit     ", 16
             "Hi%20This%20is%20Rohit"
         */
    public class URLify
    {
        public static string URLifyString(string inputString, int length)
        {
            //char[] outputString = new char[length];
            StringBuilder outputString = new StringBuilder();
            bool isWhiteSpace = false;
            for(int i =0; i < inputString.Length;i++)
            {
                if (inputString[i] == ' ')
                {
                    isWhiteSpace = true;
                }
                else
                {
                    if (isWhiteSpace)
                    {
                        outputString.Append("%20");
                    }
                    isWhiteSpace = false;
                    outputString.Append(inputString[i]);
                }
            }
            return outputString.ToString();
        }
    }
}
