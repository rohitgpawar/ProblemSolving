/*
 •	Design a recursive algorithm (in pseudo-code) according to the given idea to find the number of distinct elements in a SORTED array. 
 E.g. in the array 1 1 2 2 2 4 4 4 4 4 5 7 9 9, the algorithm should return 6 because there are 6 distinct elements (1 2 4 5 7 9).
 */

using System;

namespace ProblemSolving
{
    public class DistinctCount
    {
        public static int CountDistinct(int[] array, int index, int countDistinct)
        {
            if (array.Length - 1 > index)
            {
                if (array[index] != array[index + 1])
                {
                    countDistinct++;
                }
                //else
                {
                    countDistinct = CountDistinct(array, index + 1, countDistinct);
                }
            }
            return countDistinct;
        }
    }
}
