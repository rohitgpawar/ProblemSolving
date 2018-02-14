/*
 Sliding Window Maximum (Maximum of all subarrays of size k)
3.5
Given an array and an integer k, find the maximum for each and every contiguous subarray of size k.

Examples:

Input :
arr[] = {1, 2, 3, 1, 4, 5, 2, 3, 6}
k = 3
Output :
3 3 4 5 5 5 6

Input :
arr[] = {8, 5, 10, 7, 9, 4, 15, 12, 90, 13}
k = 4
Output :
10 10 10 15 15 90 90
 */

using System.Collections;
using System.Collections.Generic;

namespace ProblemSolving
{
    public class SlidingWindowMaxAndMin
    {
        public static void SlidingWindowMaxAndMinMain()
        {
            int[] array = new int[] { 8, 5, 10, 7, 9, 4, 15, 12, 90, 13 };
            PrintSlidingWindowMinAndMax(array, 3);
        }

        /// <summary>
        /// Print Min and Max in sliding Window.
        /// </summary>
        /// <param name="array"></param>
        public static void PrintSlidingWindowMinAndMax(int[] array, int windowSize)
        {
            //Stores index of max in any window and stores other elements lower than that. First will always be max
            LinkedList<int> dequeue = new LinkedList<int>();

            //Add max in first window to dequeue
            for (int i = 0; i < windowSize; i++)
            {
                while(dequeue.Count > 0 && array[i] >= array[dequeue.Last.Value])
                {//while current element is greater than last element remove last element index
                    dequeue.RemoveLast();
                }
                dequeue.AddLast(i); //Add current index to LL
            }

            for (int i = windowSize; i < array.Length; i++)
            {
                //Print Max of previous window
                System.Console.Write(" "+array[dequeue.First.Value]);
                //If dequeue first element out of window context then remove that
                if(dequeue.Count > 0 && dequeue.First.Value <= i-windowSize)
                {// This index is not in current window so remove it
                    dequeue.RemoveFirst();
                }

                while(dequeue.Count > 0 && array[i] >= array[dequeue.Last.Value])
                {//while current element is greater then last element index then remove Last from dequeue
                    dequeue.RemoveLast();
                }

                dequeue.AddLast(i);//Add element to last.
            }

            //Print Max of last window
            System.Console.Write(" " + array[dequeue.First.Value]);

        }

    }
}
