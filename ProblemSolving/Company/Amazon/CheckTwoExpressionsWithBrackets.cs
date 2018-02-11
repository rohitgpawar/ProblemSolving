/*
 Check if two expressions with brackets are same
4
Given two expressions in the form of strings. The task is to compare them and check if they are similar. Expressions consist of lowercase alphabets, ‘+’, ‘-‘ and ‘( )’.

Examples:

Input  : exp1 = "-(a+b+c)"
         exp2 = "-a-b-c"
Output : Yes

Input  : exp1 = "-(c+b+a)"
         exp2 = "-c-b-a"
Output : Yes

Input  : exp1 = "a-b-(c-d)"
         exp2 = "a-b-c-d"
Output : No
It may be assumed that there are at most 26 operands from ‘a’ to ‘z’ and every operand appears only once.
 */

using System.Collections;
using System.Collections.Generic;

namespace ProblemSolving
{
    public class CheckTwoExpressionsWithBrackets
    {
        public static void CheckTwoExpressionsWithBracketsMain()
        {
            string expression1 = "a-b-(c-d)";
            string expression2 = "a-b-c-d";
            expression1 = ConvertExpession(expression1);
            if(expression1.Equals(expression2)) // Expressions are equal
                System.Console.WriteLine("YES");
            else
                System.Console.WriteLine("NO");
        }

        /// <summary>
        /// Convert the given expression to remove all brackets
        /// </summary>
        /// <param name="expression"></param>
        public static string ConvertExpession(string expression)
        {
            Stack<char> signs = new Stack<char>();
            string expressionOutput = "";
            bool inBracket = false;
            foreach(char currentChar in expression)
            {// Loop till last char of string;
                if (currentChar == '-' || currentChar == '+')
                {// If sign
                    if (signs.Count == 0)
                    {
                        signs.Push(currentChar);
                    }
                    else
                    {// Peek from signs and compute sign
                        char lastSign = signs.Peek();
                        if (lastSign == '-')
                        {// Flip the sign
                            signs.Push(currentChar == '-' ? '+' : '-');
                        }
                    }
                }
                else if (currentChar == '(')
                {
                    inBracket = true;
                }
                else if (currentChar == ')')
                {// Remove stored sign
                    inBracket = false;
                    signs.Pop();
                }
                else if (currentChar > 96 && currentChar < 104)
                {// its operand
                    char sign = ' ';
                    if (inBracket && signs.Count == 1)
                    {// Sign is stored for bracket
                        sign = signs.Peek();
                    }
                    else if(signs.Count > 0)
                    {// Pop last sign
                        sign = signs.Pop();
                    }
                    expressionOutput = expressionOutput + ' ' + sign + ' ' + currentChar;
                }
            }
            return expressionOutput.Replace(" ","");
        }
    }
}
