/*
  Find Common in 3 array lists
 */

using System;

namespace ProblemSolving
{
    public class FindCommonIn3List
    {
        public static void FindCommonElements(int[] arr1, int[] arr2, int[] arr3)
        {

            int length1 = arr1.Length;
            int length2 = arr2.Length;
            int length3 = arr3.Length;
            int position1 = 0;
            int position2 = 0;
            int position3 = 0;
            while (position1 < length1  && position2 < length2  && position3 < length3)
            {
                if (arr1[position1] == arr2[position2] && arr2[position2] == arr3[position3])
                {
                    Console.Write(arr1[position1]);
                    //if (position1 < length1 - 1)
                        position1++;
                    //if (position2 < length2 - 1)
                        position2++;
                    //if (position3 < length3 - 1)
                        position3++;
                }
                else if (arr1[position1] < arr2[position2])
                {
                    //if (position1 < length1 - 1)
                        position1++;
                }
                else if (arr2[position2] < arr3[position3])
                {
                   // if (position2 < length2 - 1)
                        position2++;
                }
                else if (arr3[position3] < arr1[position1])
                {
                    //if (position3 < length1 - 1)
                        position3++;
                }
                
            }
        }
    }
}
