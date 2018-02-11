/*
 Find minimum number of merge operations to make an array palindrome
Given an array of positive integers. We need to make the given array a ‘Palindrome’. Only allowed operation on array is merge. Merging two adjacent elements means replacing them with their sum. The task is to find minimum number of merge operations required to make given array a ‘Palindrome’.

To make an array a palindromic we can simply apply merging operations n-1 times where n is the size of array (Note a single element array is alway palindrome similar to single character string). In that case, size of array will be reduced to 1. But in this problem we are asked to do it in minimum number of operations.

Example:

Input : arr[] = {15, 4, 15}
Output : 0
Array is already a palindrome. So we
do not need any merge operation.

Input : arr[] = {1, 4, 5, 1}
Output : 1
We can make given array palindrome with
minimum one merging (merging 4 and 5 to
make 9)

Input : arr[] = {11, 14, 15, 99}
Output : 3
We need to merge all elements to make
a palindrome.

{ 1, 2, 1, 1, 3, 1}
 */
namespace ProblemSolving
{
    class MakeArrayPalindromeInMinMerge
    {
        public static void MakeArrayPalindromeInMinMergeMain()
        {
            int[] array = new int[4] { 1, 4, 5, 1 };
            int minMerge = GetMinMergeForPalindrome(array);
        }

        
        /// <summary>
        /// Calculates min number of merge to make array Palindrome
        /// </summary>
        /// <returns></returns>
        public static int GetMinMergeForPalindrome(int[] array)
        {
            int mergeCount = 0;
            int leftCounter = 0;
            int leftValue = array[leftCounter]; // store left value
            int rightCounter = array.Length - 1;
            int rightValue = array[rightCounter]; // store right value

            while(leftCounter < rightCounter)
            {// continue till left doesn't cross right
                if(leftValue == rightValue)
                {// Both Values match so move both counters
                    leftCounter++;
                    rightCounter--;
                    leftValue = array[leftCounter];
                    rightValue = array[rightCounter];
                }
                else
                {// values dont match
                    if(leftValue < rightValue)
                    {//add next element to left
                        leftValue += array[++leftCounter];
                        mergeCount++;
                    }
                    else
                    {// right value is smaller
                        rightValue += array[--rightCounter];
                        mergeCount++;
                    }
                }

            }

            return mergeCount;
        }
    }
}
