/*
 •	Write a recursive algorithm in pseudo-code to output the binary representation for non-negative integers.
 
 Binary form of any number can be obtained by successive divisions of the given number by 2 :

11/2 = 5 + 1/2

5/2 = 2 + 1/2

2/2 = 1 + 0/2

1/2 = 0 + 1/2
 */
using System;

namespace ProblemSolving
{
    public class IntToBinary
    {
        public static void GetBinary(int number)
        {
            int quotient = number / 2;
            int reminder = number % 2;
            if (quotient > 0)
            {
                GetBinary(quotient);
            }
            Console.Write(reminder);
        }
    }
}
