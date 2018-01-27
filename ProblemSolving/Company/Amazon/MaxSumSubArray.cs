/*
 
Largest Sum Contiguous Subarray
Maximum sum subarray from array having positive and negative numbers both.

 */

namespace ProblemSolving
{
    public class MaxSumSubArray
    {
        public static int start;
        public static int end;
        public static void MaxSumSubArrayMain()
        {
            int maxSum = GetMaxSumSubArray(new int[5] { 1, 2, 0, -3, 4 });
        }

        /// <summary>
        /// Get Max Sum Sub Array with start and end index
        /// </summary>
        /// <param name="array"></param>
        public static int GetMaxSumSubArray(int[] array)
        {
            int localSum = 0;
            int maxSum = 0;
            int s = 0;
            for (int i = 0; i < array.Length; i++)
            {
                localSum += array[i];
                if(maxSum < localSum)
                {//If localSum is Max then set it as maxSum, set start as last s and end as current index i
                    maxSum = localSum;
                    start = s;
                    end = i;
                }
                if(localSum < 0)
                {// If localSum is negative set it back to 0 and start to next index
                    localSum = 0;
                    s = i + 1;
                }
            }
            return maxSum;
        }
    }
}
