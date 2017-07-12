using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
/**
 A string contains many patterns of the form 1(0+)1 where (0+) represents any non-empty consecutive sequence of 0's. The patterns are allowed to overlap. 
     
100001abc101        = 2
1001ab010abc01001   = 2
1001010001          = 3
     
     */
public class PatternMatch
{

    static int patternCount(string s)
    {
        int counter = 0;
        bool oneInPattern = false;
        bool zeroPresentInPattern = false;
        foreach (char c in s)
        {
            Console.WriteLine(c == '1');
            if (c == '1' && !oneInPattern)
                oneInPattern = true;
            else if (oneInPattern && c == '0')
            {
                zeroPresentInPattern = true;
            }
            else if (oneInPattern && zeroPresentInPattern && c == '1')
            {
                counter++;
                zeroPresentInPattern = false;
            }
            else if (c == '1')
                oneInPattern = true;
            else
            {
                oneInPattern = false;
                zeroPresentInPattern = false;
            }
        }
        return counter;
        // Complete this function
    }

    public static void PatternMatchMain()
    {
        string s = "010aa11";
        int result = patternCount(s);
        Console.WriteLine(result);
        
    }
}