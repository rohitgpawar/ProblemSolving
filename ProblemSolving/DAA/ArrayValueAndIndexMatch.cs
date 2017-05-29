/*
 •	Given a sorted array with n distinct integers, the array’s indexes start from 1 to n. Design an O(log n) 
 time algorithm in pseudo-code to check whether there is an element in the array such that A[j]=j.For example, the array [-1,0,3,5,9] returns true since the 
 index for the third element is 3 and its value is also 3; while the array [9,19,26,58] return false. Justify the correctness and time efficiency of your algorithm.
 */

namespace ProblemSolving
{
    public class ArrayValueAndIndexMatch
    {
        public static bool FindMatching(int[] array, int start, int end)
        {
            bool matchFound = false;
            int mid = (start + end) / 2;
            if (array[mid] == mid)
            {
                return true;
            }
            if (start == end)
            {
                return false;
            }
            matchFound = FindMatching(array, start, mid);
            if (!matchFound)
            {
                matchFound = FindMatching(array, mid + 1, end);
            }
            return matchFound;
        }
    }
}
