using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    public class LongestValidParenthesis
    {

        static public void Start()
        {
            string inputParenthesis = ")()(((){}[][()]";

            char[] parenthesisList = inputParenthesis.ToCharArray();

            Stack<char> parenthesisStack = new Stack<char>();
            int validParenthesis = 0;
            foreach (char parenthesis in parenthesisList)
            {
                if (parenthesisStack.Count != 0 && parenthesis == parenthesisStack.Peek())
                {
                    validParenthesis = validParenthesis + 2;
                    parenthesisStack.Pop();
                }
                else
                    switch (parenthesis)
                    {
                        case '{':
                            parenthesisStack.Push('}');
                            break;
                        case '(':
                            parenthesisStack.Push(')');
                            break;
                        case '[':
                            parenthesisStack.Push(']');
                            break;
                        default:
                            parenthesisStack.Push(parenthesis);
                            break;
                    }
            }
            Console.WriteLine(validParenthesis);
            Console.ReadLine();
        }
    }
}
