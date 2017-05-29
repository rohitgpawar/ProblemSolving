
using System;

namespace ProblemSolving
{
    public class MinSubArrayWithValue
    {

        public static void FindShortestSubArrayWithValue(int[] array, int value)
        {
            int sum = 0;
            int higherIndex = 0;
            int lowerIndex = 0;
            while (higherIndex < array.Length)
            {
                sum += array[higherIndex];
                if (sum > value)
                {
                    break;
                }
                higherIndex++;
            }
            while (sum - array[lowerIndex] > value)
            {
                sum = sum - array[lowerIndex];
                lowerIndex++;
            }
            Console.WriteLine("Min Length:-{0}", higherIndex - lowerIndex + 1);

            for (int i = lowerIndex; i <= higherIndex; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
