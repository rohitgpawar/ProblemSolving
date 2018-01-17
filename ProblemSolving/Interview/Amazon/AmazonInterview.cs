using System.Collections.Generic;

namespace ProblemSolving
{
    public class AmazonInterview
    {
        //Amazon Interview Question 2
        public static List<int> lengthEachScene(List<char> inputList)
        {
            // WRITE YOUR CODE HERE

            //Holds output 
            List<int> lengthOfEachScene = new List<int>();
            //Holds count of characher 
            int[] charCount = new int[256];
            //Holds characherters ascii occuring in subsequence
            HashSet<int> charsInSubSequence = new HashSet<int>();
            foreach (char ch in inputList)
            {//Count occurance of charachers in the input
                charCount[ch]++;
            }
            //Holds lenght of scene
            int sceneLength = 0;
            foreach (char ch in inputList)
            {
                sceneLength++;
                if (!charsInSubSequence.Contains(ch))
                    charsInSubSequence.Add(ch);
                charCount[ch]--;
                //Holds if all charachers are visited
                bool allSubVisited = true;
                foreach (int charInSubSequence in charsInSubSequence)
                {// check if all charachters count in subsequence is 0 
                    if (charCount[charInSubSequence] != 0)
                    {
                        allSubVisited = false;
                    }
                }
                if (allSubVisited)
                {//If all charachters visited then add length to output
                    lengthOfEachScene.Add(sceneLength);
                    sceneLength = 0;
                }
            }

            return lengthOfEachScene;
        }

        ////Amazon Interview Question 1
        public static List<string> subStringsKDist(string inputStr, int num)
        {
            // WRITE YOUR CODE HERE

            //HashSet to store unique subStrings
            HashSet<string> uniqueSubstringList = new HashSet<string>();
            //Holds the output to be returned
            List<string> outputSubstring = new List<string>();
            for (int i = 0; i < inputStr.Length; i++)
            {//Iterate over the length of input string.
             //Stores unique charachters to identity distinct characters.
                bool[] charachters = new bool[27];
                //Stores if the substring in unique.
                bool isUniqueSubString = true;
                if (i + num <= inputStr.Length)
                {//Iterate over the size of substring (num)
                    for (int j = i; j < i + num; j++)
                    {// Iterates over each charachter in the substring;   
                        if (!charachters[inputStr[j] - 97])
                        {//stores first occurance of charachter
                            charachters[inputStr[j] - 97] = true;
                        }
                        else
                        {// charachter is repeated in substring
                            isUniqueSubString = false;
                            break;
                        }
                    }
                    if (isUniqueSubString)
                    {// all charachters are distinct in current substring.
                        if (!uniqueSubstringList.Contains(inputStr.Substring(i, num)))
                        {// first occurance of substring.
                         //Add substring to the HashSet;
                            uniqueSubstringList.Add(inputStr.Substring(i, num));
                            //Add substring to the output;
                            outputSubstring.Add(inputStr.Substring(i, num));
                        }
                    }
                }
            }

            return outputSubstring;

        }
    }
}
