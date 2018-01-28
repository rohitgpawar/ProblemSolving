/*
 Implementation of Merge Sort
 */

namespace ProblemSolving.Sorting
{
    public class MergeSort
    {
        /// <summary>
        /// This method with sort the given array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        public static void ApplyMergeSort(int[] array,int startPos, int endPos)
        {
            if (startPos < endPos)
            {//If array can be divided
                int mid = (startPos + endPos) / 2;

                ApplyMergeSort(array, startPos, mid);//Recursive on first half of array
                ApplyMergeSort(array, mid + 1, endPos);//Recursive on second half of array

                MergeWithSort(array, startPos, mid, endPos);//Merge the two halfs
            }
        }

        /// <summary>
        /// Merge the two halfs and sort while merging
        /// </summary>
        /// <param name="array"></param>
        /// <param name="startPos"></param>
        /// <param name="midPos"></param>
        /// <param name="endPos"></param>
        private static void MergeWithSort(int[] array, int startPos, int midPos,int endPos)
        {
            int[] temp = new int[endPos-startPos+1];
            int tempPos = 0;
            int leftPos = startPos;
            int rightPos = midPos + 1;
            while(leftPos<=midPos && rightPos<=endPos)
            {//While both halfs have elements compare and enter in correct position
                if(array[leftPos] < array[rightPos])
                {//Left half value is smaller then pick that in output
                    temp[tempPos] = array[leftPos];
                    leftPos++;
                }
                else
                {//Right value is smaller then pick that in output
                    temp[tempPos] = array[rightPos];
                    rightPos++;
                }
                tempPos++;
            }
            while(leftPos <= midPos)
            {//add remaining elements from left array
                temp[tempPos] = array[leftPos];
                leftPos++;
                tempPos++;
            }
            while(rightPos <= endPos)
            {//add remaining elements from right array
                temp[tempPos] = array[rightPos];
                rightPos++;
                tempPos++;
            }
            tempPos = 0;
            for(int i=startPos;i<=endPos;i++)
            {
                array[i] = temp[tempPos];
                tempPos++;
            }
        }
    }
}
