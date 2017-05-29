/*
 •	Design a recursivealgorithmin pseudo-code to print a given array with n elements in reverse order. 
 For example, if the input is [3,5,1,7, 9], then the output is 9,7,1,5,3. 
 No credits will be given if you use a for-loop-like algorithm.
 */

using System;

namespace ProblemSolving
{
    public class ReverseArrayRecursion
    {
        public static void MakeArrayReverse(int[] array, int position)
        {
            if (array.Length - 1 == position)
            {
                Console.Write(array[position]);
            }
            else
            {
                MakeArrayReverse(array, position + 1);
                Console.Write(array[position]);
            }
            //if ( position < array.Length)
            //{
            //    MakeArrayReverse(array, position + 1);

            //    Console.Write(array[position]);
            //}
        }
    }
}
