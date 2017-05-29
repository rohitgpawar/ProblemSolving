/*
 •	Let A be a decreasing array. Design a o(n)-time (little-o time) algorithm to return the index of its largest negative number,
 if no such number exists, then return -1.For example, for the array [9,7,5,0,-3,-7], your algorithm returns 5 since the 5-th element 
 is the largest negative number. For the array [9,7,5], your algorithm returns -1.  
 If you use recursion, then you need to state your initial call.
 */
namespace ProblemSolving
{
    public class FindLargestNegativeNumber
    {
        public static int FindLargestNegativeInArray(int[] array, int start, int end)
        {
            int answer = -1;
            if (start == end)
            {
                return array[start] < 0 ? array[start] : -1;
            }
            int mid = (start + end) / 2;
            if (array[mid] < 0)
            {
                answer = FindLargestNegativeInArray(array, start, mid);
            }
            else if (array[mid] >= 0)
            {
                answer = FindLargestNegativeInArray(array, mid + 1, end);
            }
            return answer;
        }
    }
}
