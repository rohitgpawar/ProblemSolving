
using System;

namespace ProblemSolving
{
    public class LargestInConcaveArray
    {
        public static int GetLargestInConcaveArray(int[] arry)
        {
            
            int left = 0;
            int right = arry.Length;
            int mid = 0;
            while (left <= right)
            {
                if (left == right)
                {
                    Console.WriteLine(arry[left]);
                    return arry[left];
                }
                mid = (left + right) / 2;
                if (arry[mid] < arry[mid + 1])
                {
                    left = mid + 1;
                }
                else // arry[mid] >= arry[mid+1]
                    right = mid;
            }

            return -1;
        }
    }
}
