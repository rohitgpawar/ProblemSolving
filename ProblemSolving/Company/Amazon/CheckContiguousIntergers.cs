/*

Check if array contains contiguous integers with duplicates allowed

Given an array of n integers(duplicates allowed). Print “Yes” if it is a set of contiguous integers else print “No”. 

Input : arr[] = {5, 2, 3, 6, 4, 4, 6, 6}
Output : Yes
The elements form a contiguous set of integers
which is {2, 3, 4, 5, 6}.

Input : arr[] = {10, 14, 10, 12, 12, 13, 15}
Output : No

 */

using System.Collections.Generic;

namespace ProblemSolving
{
    public class CheckContiguousIntergers
    {
        public static void CheckContiguousIntergersMain()
        {
            bool isContiguous = CheckIfContiguousIntegers(new int[8] { 10, 14, 10, 12, 12, 13, 15,16 });
        }

        public static bool CheckIfContiguousIntegers(int[] array)
        {
            HashSet<int> numbersPresent = new HashSet<int>();
            int min = int.MaxValue;
            int max = int.MinValue;
            for(int i =0; i< array.Length; i++)
            {
                if(!numbersPresent.Contains(array[i]))
                {//If not present add to HashSet
                    numbersPresent.Add(array[i]);
                }
                if(array[i]<min)
                {//Store min value
                    min = array[i];
                }
                if(array[i]>max)
                {//Store max value
                    max = array[i];
                }
            }

            if(max-min >= array.Length)
            {// Array should have atleast max-min elements
                return false;
            }

            while(min<=max)
            {//Check if all numbers from min to max are present in HashSet
                if(!numbersPresent.Contains(min))
                {
                    return false;
                }
                min++;
            }
            return true;
        }
    }
}
