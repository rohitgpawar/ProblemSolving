/*
 •	A strict concave-up array is an array in which the numbers first strictly decrease,then the numbers strictly increases.
 For example, [5,3,1,6,9,12] is a strict concave-up array. Note that, the decreasing part and/or the increasing part could be empty.  
 So [5,3,1] and [1,6,9,12] are both strict concave-up arrays. Even the array [3] is also a strict concave-up array. 
 A strict concave-up array always has a unique smallest element. 
 In this problem, you are asked to present an O(lgn)-time algorithm in pseudo-code to find the smallest element in a given strict concave-up array. 
 Please also specify your initial call (top level call).
 You need to justify the running time by stating the recurrence relation for the recursive algorithm.
 */
namespace ProblemSolving
{
    public class FindMin
    {
        public static int FindMinInArray(int[] array, int start, int end)
        {
            int answer = 0;
            if (start == end)
            {
                return array[start];
            }
            int mid = (start + end) / 2;
            if (array[mid] < array[mid + 1])
            {
                answer = FindMinInArray(array, start, mid);
            }
            else if (array[mid] > array[mid + 1])
            {
                answer = FindMinInArray(array, mid + 1, end);
            }

            return answer;
        }
    }
}
