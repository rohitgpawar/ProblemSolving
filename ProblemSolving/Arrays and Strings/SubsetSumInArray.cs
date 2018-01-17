using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    /// <summary>
    /* Given a set of non-negative integers, and a value sum, determine if there is a subset of the given set with sum equal to given sum.

        Examples: set[] = {3, 34, 4, 12, 5, 2}, sum = 9
        Output:  True  //There is a subset (4, 5) with sum 9.
        https://www.geeksforgeeks.org/dynamic-programming-subset-sum-problem/
    */// </summary>
    public class SubsetSumInArray
    {
        public static void SubsetSumInArrayMain()
        {
            bool isSubset = GetSubsetSumInArray(new int[] { 3, 34, 4, 12, 5, 2 }, 9);
        }

        public static bool GetSubsetSumInArray(int[] array, int sum)
        {
            bool[][] subset = new bool[array.Length + 1][];

            for (int i = 0; i <= array.Length; i++)
            {
                subset[i] = new bool[sum + 1];
                subset[i][0] = true;
            }

            for(int i=0;i<=sum;i++)
            {
                subset[0][i] = false;
            }

            for(int i=1;i<=array.Length;i++)
            {
                for(int j=1;j<=sum;j++)
                {
                    subset[i][j] = (j < array[i-1]) ? subset[i - 1][j] : subset[i - 1][j] || subset[i - 1][j - array[i-1]];
                }
            }

            return subset[array.Length][sum];


        }
    }
}
