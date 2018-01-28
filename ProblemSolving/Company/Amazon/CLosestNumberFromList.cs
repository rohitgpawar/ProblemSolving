/*
 
Closest numbers from a list of unsorted integers

Given a list of distinct unsorted integers, find the pair of elements that have the smallest absolute difference between them? 
If there are multiple pairs, find them all.

Input : arr[] = {10, 50, 12, 100}
Output : (10, 12)
The closest elements are 10 and 12

Input : arr[] = {5, 4, 3, 2}
Output : (2, 3), (3, 4), (4, 5)
 */

using System;

namespace ProblemSolving
{
    public class ClosestNumberFromList
    {
        public static void ClosestNumberFromListMain()
        {
            int[] list = new int[4] { 10, 50, 12, 100 };
            FindClosestNumberFromList(list);
        }
        /// <summary>
        /// Get the closest numbers from the given list
        /// </summary>
        /// <param name="array"></param>
        public static void FindClosestNumberFromList(int[] array)
        {
            //Sort the List
            Sorting.MergeSort.ApplyMergeSort(array,0,array.Length-1);

            int minDist = int.MaxValue;
            for (int i = 1; i < array.Length; i++)
            {//Compare consicutive values and store the min.
                int currentDist = Math.Abs(array[i - 1] - array[i]);
                if (currentDist < minDist)
                {
                    minDist = currentDist;
                }
            }
            Console.WriteLine("Min Distance is :{0}",minDist);
            for (int i = 1; i < array.Length; i++)
            {
                int currentDistance = Math.Abs(array[i - 1] - array[i]);
                if(currentDistance==minDist)
                {
                    Console.Write("({0},{1})",array[i-1],array[i]);
                }
            }

        }
    }
}
