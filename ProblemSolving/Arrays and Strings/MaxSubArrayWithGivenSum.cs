using System.Collections;
using System.Collections.Generic;

namespace ProblemSolving
{
    /// <summary>
    /// Find the Length of max subarray whose sum is zero
    /// </summary>
    public class MaxSubArrayWithGivenSum
    {
        public static void MaxSubArrayWithGivenSumMain()
        {
            int[] arraySum = new int[] { 6, 3, -1, -3, 4, -2, 2, 4, 6, -12, -7 };
            List<int[]> tet = GetMaxSubArrayWithGivenSum(arraySum);
        }
        //GetMaxSubArrayWithGivenSum(array, array.Length,0,0)
        public static List<int[]> GetMaxSubArrayWithGivenSum(int[] array)
        {
            List<int[]> indicesWithSumZero = new List<int[]>();
            Dictionary<int, List<int>> sumTable = new Dictionary<int, List<int>>();
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
                if (sum == 0)
                {
                    int[] t = new int[2];
                    t[0] = 0;
                    t[1] = i;
                    indicesWithSumZero.Add(t);
                }
                if (sumTable.ContainsKey(sum))
                {
                    List<int> temp = sumTable[sum];
                    foreach (int te in temp)
                    {
                        int[] t = new int[2];
                        t[0] = te;
                        t[1] = i;
                        indicesWithSumZero.Add(t);
                    }
                }
                if(sumTable.ContainsKey(sum))
                {
                    sumTable[sum].Add(i);
                }
                else
                {
                    List<int> pair = new List<int>() { i };
                    sumTable.Add(sum, pair);
                }
                
            }
            return indicesWithSumZero;
        }
    }
}
