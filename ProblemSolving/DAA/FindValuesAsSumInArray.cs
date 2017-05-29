/*
 •	Let A be a sorted array and x be a number. Write anO(n)-time recursive algorithm to test whether 
 there are two distinct entries in A such that their sum is x. Your algorithm should return false or true. 
 Please also specify your initial call (top level call).You need to justify the running time by stating the 
 recurrence relation for the recursive algorithm.
 */
using System.Collections.Generic;

namespace ProblemSolving
{
    public class FindValuesAsSumInArray
    {
        public static bool FindSumInArray(int[] array, int index, int sum, Stack<int> neededNumbers)
        {
            bool sumFound = false;
            int neededNumber = sum - array[index];
            if (index < array.Length - 1)
            {
                if (neededNumbers.Count == 0)
                {
                    neededNumbers.Push(neededNumber);
                    sumFound = FindSumInArray(array, index + 1, sum, neededNumbers);
                }
                else
                {
                    if (array[index] == neededNumbers.Peek())
                    {
                        return true;
                    }
                    else if (neededNumber >= array[index])
                    {
                        neededNumbers.Push(neededNumber);
                        sumFound = FindSumInArray(array, index + 1, sum, neededNumbers);
                    }
                    else if (neededNumbers.Peek() < array[index])   
                    {
                        while (neededNumbers.Peek() < array[index])
                        {
                            neededNumbers.Pop();
                        }

                        if (array[index] == neededNumbers.Peek())
                        {
                            return true;
                        }
                        else
                        {
                            sumFound = FindSumInArray(array, index + 1, sum, neededNumbers);
                        }
                    }
                }

            }
            return sumFound;

        }
    }
}
