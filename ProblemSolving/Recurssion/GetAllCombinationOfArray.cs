using System.Collections.Generic;

namespace ProblemSolving
{
    public class GetAllCombinationOfArray
    {
        static List<List<int>> combinations = new List<List<int>>();
        public static void GetAllCombinationOfArrayMain()
        {
            List<int> array = new List<int> { 1, 2, 3 };
            combinations = new List<List<int>>();
            GetAllCombination(array, 0,new int[array.Count], 0);

        }

        public static void GetAllCombination(List<int> array, int start, int[] combination, int index)
        {
            if(start == array.Count)
            {
                combinations.Add(new List<int>(combination));
                return;
            }

            if (start >= array.Count)
                return;

            for (int i = start; i < array.Count; i++)
            {
                combination[start] = array[i];
                int swap = array[i];
                array[i] = array[start];
                array[start] = swap;
                GetAllCombination(new List<int>(array), start + 1, combination, index);
            }
        }
    }
}
