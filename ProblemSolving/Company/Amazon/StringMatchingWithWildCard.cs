/*
 String matching where one string contains wildcard characters

 Given two strings where first string may contain wild card characters and second string is a normal string. 
 Write a function that returns true if the two strings match. The following are allowed wild card characters in first string.

* --> Matches with 0 or more instances of any character or set of characters.
? --> Matches with any one character.

For example, “g*ks” matches with “geeks” match. And string “ge?ks*” matches with “geeksforgeeks” (note ‘*’ at the end of first string).
But “g*k” doesn’t match with “gee” as character ‘k’ is not present in second string.

a*, aab*, abcb*c, ba*.c*, a.b, a*b etc etc and edge cases
 */
namespace ProblemSolving
{
    public class StringMatchingWithWildCard
    {
        public static void StringMatchingWithWildCardMain()
        {
            string text = "bafcc";
            string expression = "ba*?c*";
            //bool match = CheckStringMatchWithPattern(text, expression, 0, 0);
            bool match = CheckStringMathWithPatternUsingDP(text, expression);
        }

        /// <summary>
        /// Match pattern with string return true if matched
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool CheckStringMatchWithPattern(string text, string pattern, int patternCounter, int textCounter)
        {
            if (patternCounter == pattern.Length)
            {//Reached Pattern End
                return false;
            }

            if (textCounter == text.Length-1 && patternCounter == pattern.Length-1)
            {// Reached the end
                return true;
            }
            if(patternCounter == pattern.Length - 1 && pattern[patternCounter] == '*')
            {//Last char of pattern is * so everything from here matches
                return true;
            }

            if (patternCounter < pattern.Length - 1 && pattern[patternCounter] == '*' && textCounter == text.Length - 1)
            {//Char after * are not present as we have reached end to text
                return false;
            }

            if (pattern[patternCounter] == '*')
            {//Two options consider current char in text or move to next char in text
                return CheckStringMatchWithPattern(text, pattern, patternCounter + 1, textCounter) ||
                    CheckStringMatchWithPattern(text, pattern, patternCounter , textCounter + 1);
            }

            if (pattern[patternCounter] == '?' || pattern[patternCounter] == text[textCounter])
            {//Match or ? found move one char for each pattern and text
                return CheckStringMatchWithPattern(text, pattern, patternCounter + 1, textCounter + 1);
            }

            return false;
        }

        /// <summary>
        /// Match patter with the string using Dynamic Programming.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool CheckStringMathWithPatternUsingDP(string text, string pattern)
        {
            bool[][] outputDP = new bool[text.Length+1][];
            for (int i = 0; i <= text.Length; i++)
            {//initialize the output bool array.
                outputDP[i] = new bool[pattern.Length+1];
            }

            //Initialize first to be true. Everything matches for empty Pattern and empty string.
            outputDP[0][0] = true;

            for (int patternCounter = 1; patternCounter <= pattern.Length; patternCounter++)
            {//
                if (pattern[patternCounter - 1].Equals('*'))
                {
                    outputDP[0][patternCounter] = outputDP[0][patternCounter - 1];
                }
            }

            for (int textCounter = 1; textCounter <= text.Length; textCounter++)
            {//Loop on all char of text
                for (int patternCounter=1; patternCounter<= pattern.Length;patternCounter++)
                {//Loop on all char in pattern
                    if(pattern[patternCounter-1].Equals('*'))
                    {//Pattern is * so we can have 2 cases 
                        //1. consider this pattern char as null and move to next
                        //2. consider this pattern char matches with text char and move char next
                        outputDP[textCounter][patternCounter] = outputDP[textCounter][patternCounter - 1] || outputDP[textCounter - 1][patternCounter];
                    }
                    else if(pattern[patternCounter-1].Equals('?') || pattern[patternCounter-1].Equals(text[textCounter-1]))
                    {// IF ? in pattern or match in pattern and string move both forward
                        outputDP[textCounter][patternCounter] = outputDP[textCounter - 1][patternCounter - 1];
                    }
                    else
                    {// pattern char != text char
                        outputDP[textCounter][patternCounter] = false;
                    }
                }

            }

            //Send Last Char as output
            return outputDP[text.Length][pattern.Length];
        }

        
    }
}
