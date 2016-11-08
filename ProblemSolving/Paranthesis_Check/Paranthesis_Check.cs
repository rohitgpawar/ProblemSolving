using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    public class Paranthesis_Check
    {
        public static void Start(string[] args)
        {
            //string parenthesis = "[()]{}{[()()]()}";
            //string parenthesis = "{[()())]()}";
            //string parenthesis = "}{[()())]()}";
            string parenthesis = "(){}{}{{}}{([])}";

            //string parenthesis = "[()]";
            char[] parenthesisList = parenthesis.ToCharArray();
            Stack<char> parenthesisQueue = new Stack<char>();
            for(int i=0; i<parenthesisList.Length;i++)
            {
                if (parenthesisList[i] == ')')
                {
                    if (parenthesisQueue.Count >0 && parenthesisQueue.Peek() == '(')
                    {
                        parenthesisQueue.Pop();
                    }
                    else
                    {
                        parenthesisQueue.Push(parenthesisList[i]);
                    }
                }
                else if (parenthesisList[i] == '}')
                {
                    if (parenthesisQueue.Count > 0 && parenthesisQueue.Peek() == '{')
                    {
                        parenthesisQueue.Pop();
                    }
                    else
                    {
                        parenthesisQueue.Push(parenthesisList[i]);
                    }
                }
                else if (parenthesisList[i] == ']')
                {
                    if (parenthesisQueue.Count > 0 && parenthesisQueue.Peek() == '[')
                    {
                        parenthesisQueue.Pop();
                    }
                    else
                    {
                        parenthesisQueue.Push(parenthesisList[i]);
                    }
                }
                else
                {
                    parenthesisQueue.Push(parenthesisList[i]);
                }
            }
            if (parenthesisQueue.Count == 0)
            {
                Console.WriteLine("Parenthesis " + parenthesis + " is true");
            }
            else
            {
                Console.WriteLine("Parenthesis " + parenthesis + " is false");
            }

            Console.ReadLine();
        }
    }
}
