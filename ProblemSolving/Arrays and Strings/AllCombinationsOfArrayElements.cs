/*
 Find all combination
 eg: [1,2,3] print {},{1},{2},{3},{1,2},{1,3},{1,2,3},{2,3}
 */
namespace ProblemSolving
{
    public class AllCombinationsOfArrayElements
    {
        public static void AllCombinationsOfArrayElementsMain()
        {
            FindAllCombination(new int[3] { 1, 2,3 }, 0,"");
            FindAllCombination_BinaryApproach(new int[3] { 1, 2, 3 }, 0, new int[3]);
        }

        /// <summary>
        /// using recursion without Dynamic Programing
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="store"></param>
        /// <returns></returns>
        public static void FindAllCombination(int[] array, int start, string output)
        {
            if (start == array.Length)
            {
                System.Console.WriteLine("{"+ output+"}");
                return;
            }
            //Pick start element
            FindAllCombination(array, start + 1, output + array[start] + "," );
            //Dont pick Start Element
            FindAllCombination(array, start + 1, output) ;
        }

        /// <summary>
        /// Use a array to find all the Binary cobmination when we pick one and leave one and then use it for printing
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="binaryArray"></param>
        public static void FindAllCombination_BinaryApproach(int[] array, int start, int[] binaryArray)
        {
            if(start == array.Length)
            {
                PrintArray(binaryArray,array);
                return;
            }

            binaryArray[start] = 1;
            FindAllCombination_BinaryApproach(array, start + 1, binaryArray);

            binaryArray[start] = 0;
            FindAllCombination_BinaryApproach(array, start + 1, binaryArray);
        }

        /// <summary>
        /// Print the elements according to binaryArray
        /// </summary>
        /// <param name="binaryArray"></param>
        /// <param name="array"></param>
        public static void PrintArray(int[] binaryArray, int[] array)
        {
            System.Console.Write("{");
            for (int i=0;i<binaryArray.Length;i++)
            {
                if(binaryArray[i]==1)
                {
                    System.Console.Write(+array[i] + ",");
                }
            }
            System.Console.WriteLine("}");
        }
    }
}
