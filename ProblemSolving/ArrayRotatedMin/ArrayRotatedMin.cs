
using System;

namespace ProblemSolving
{
    public class ArrayRotatedMin
    {
        public static int FindMinFromRotatedArray(int[] rotatedArray)
        {
            int[] localArray = rotatedArray;
            int startPoint = 0;
            int lastPoint = localArray.Length - 1;
            int midPoint = 0;

            while (true)
            {
                midPoint = startPoint + Convert.ToInt32((lastPoint - startPoint)/ 2);
                if (localArray[midPoint] < localArray[midPoint - 1])
                {
                    return localArray[midPoint];
                }
                else if (localArray[startPoint] > localArray[midPoint])
                {//Concentrate on first half
                    if (localArray[midPoint] > localArray[midPoint - 1])
                    {
                        lastPoint = midPoint - 1;
                    }
                    else
                    {
                        return localArray[midPoint];
                    }

                }
                else if (localArray[midPoint] > localArray[lastPoint])
                {//Concentrate on Second half.
                    if (localArray[midPoint] < localArray[midPoint + 1])
                    {
                        startPoint = midPoint + 1;
                    }
                    else
                    {
                        return localArray[midPoint +1];
                    }
                }
                else if(localArray[startPoint]< localArray[lastPoint])
                {//Array is sorted
                    return localArray[startPoint];
                }
            }
        }
    }
}
