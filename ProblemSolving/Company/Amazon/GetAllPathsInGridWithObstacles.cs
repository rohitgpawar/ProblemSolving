/*
 Unique paths in a Grid with Obstacles
2.7
Given a grid of size m * n, let us assume you are starting at (1, 1) and your goal is to reach (m, n). At any instance, if you are on (x, y), you can either go to (x, y + 1) or (x + 1, y).

Now consider if some obstacles are added to the grids. How many unique paths would there be?

An obstacle and empty space are marked as 1 and 0 respectively in the grid.

Examples:

Input: [[0, 0, 0],
        [0, 1, 0],
        [0, 0, 0]]
Output : 2
There is only one obstacle in the middle.

Count of paths from top left to right bottom in an array containing 0/1. Here 1 means blocked shell. You are allowed to move right or down

 */
using System.Collections.Generic;

namespace ProblemSolving
{
    public class GetAllPathsInGridWithObstacles
    {
        public static void GetAllPathsInGridWithObstaclesMain()
        {
            List<string> paths = new List<string>();
            int[][] array = new int[3][]; ;
            array[0] = new int[3] { 0, 0, 0 };
            array[1] = new int[3] { 0, 0, 0 };
            array[2] = new int[3] { 0, 1, 0 };
            GetAllPathsRecursive(array, 0, 0, paths, "");
            int pathsCount = GetAllPathsDP(array);
        }

        /// <summary>
        /// Get all Paths using Recursion
        /// </summary>
        /// <param name="array"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="paths"></param>
        /// <param name="path"></param>

        public static void GetAllPathsRecursive(int[][] array,int row, int col, List<string> paths, string path)
        {
            if(row == array.Length -1 && col == array[0].Length - 1)
            {//Reached End add path
                paths.Add(path + array[row][col].ToString());
            }

            if (row < array.Length - 1)
            {// next row exists
                if (array[row + 1][col] != 1)
                {//If next element is not 1
                    GetAllPathsRecursive(array, row + 1, col, paths, path + array[row][col]);
                }
            }
            if(col < array[0].Length-1)
            {// next col exists
                if(array[row][col+1] != 1)
                {// if next element is not 1
                    GetAllPathsRecursive(array, row, col + 1, paths, path + array[row][col]);
                }
            }
        }

        /// <summary>
        /// Get count of path using Dynamic Programming
        /// </summary>
        /// <param name="array"></param>
        public static int GetAllPathsDP(int[][] array)
        {
            int[][] output = new int[array.Length][];
            for(int i=0; i< array[0].Length;i++)
            {//Initialize output array
                output[i] = new int[array[0].Length];
            }
            output[0][0] = 1;
            for(int row=0;row<array.Length;row++)
            {//Iterate row
                for(int col=0;col<array[0].Length;col++)
                {//Iterate col
                    //Add current values to next values where we have path
                    if((row < (array.Length - 1)) && array[row+1][col] != 1)
                    {// Increment as path is possible 
                        output[row + 1][col] = output[row][col] + output[row + 1][col];
                    }
                    if ((col < (array[0].Length-1)) && array[row][col+1] != 1)
                    {// Increment as path is possible 
                        output[row][col+1] = output[row][col] + output[row][col+1];
                    }
                }
            }
            return output[array.Length-1][array[0].Length-1];
        }
    }
}
