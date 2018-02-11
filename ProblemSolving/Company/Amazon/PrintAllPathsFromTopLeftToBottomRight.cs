/*
 Print all possible paths from top left to bottom right of a mXn matrix

 Input : 1 2 3
        4 5 6
Output : 1 4 5 6
         1 2 5 6
         1 2 3 6

Input : 1 2 
        3 4
Output : 1 2 4
         1 3 4
 */

using System.Collections.Generic;

namespace ProblemSolving
{
    public class PrintAllPathsFromTopLeftToBottomRight
    {
        public static void PrintAllPathsFromTopLeftToBottomRightMain()
        {
            List<string> paths = new List<string>();
            int[][] array = new int[2][]; ;
            array[0] = new int[3] { 1, 2,3 };
            array[1] = new int[3] {  4,5,6 };
            PrintPaths(array, 0, 0, paths, "");
        }

        public static List<string> PrintPaths(int[][] array, int row, int col,List<string> paths, string path)
        {
            if (row == array.Length - 1 && col == array[0].Length - 1)
            {//Reached bottom right
                paths.Add(path + array[row][col].ToString());
            }

            if (row < array.Length - 1)
            {//Keep looking for right bottom
                PrintPaths(array, row + 1, col, paths, path+array[row][col].ToString());
            }
            if (col < array[0].Length - 1)
            {//Keep looking for right bottom
                PrintPaths(array, row, col + 1,paths, path + array[row][col].ToString());
            }

            return paths;
            
        }
    }
}
