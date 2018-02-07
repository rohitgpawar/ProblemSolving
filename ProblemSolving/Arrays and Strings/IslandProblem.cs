
using System;
using System.Collections.Generic;
/*
Given a boolean 2D matrix, find the number of islands. A group of connected 1s forms an island. For example, the below matrix contains 5 islands

Input : mat[][] = {{1, 1, 0, 0, 0},
{0, 1, 0, 0, 1},
{1, 0, 0, 1, 1},
{0, 0, 0, 0, 0},
{1, 0, 1, 0, 1} 
Output : 5
*/
namespace ProblemSolving
{
    public class IslandProblem
    {

        public static void IslandProblemMain()
        {
            int[,] matrix = new int[4, 4];
            matrix[0, 0] = 0;
            matrix[0, 1] = 1;
            matrix[0, 2] = 0;
            matrix[0, 3] = 0;
            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            matrix[1, 2] = 0;
            matrix[1, 3] = 1;
            matrix[2, 0] = 1;
            matrix[2, 1] = 1;
            matrix[2, 2] = 0;
            matrix[2, 3] = 1;
            matrix[3, 0] = 0;
            matrix[3, 1] = 1;
            matrix[3, 2] = 0;
            matrix[3, 3] = 0;
            GetWaterBodiesByLength(matrix);
            CountIslands(matrix);
        }
        /// <summary>
        /// Count the islands in the given matrix
        /// </summary>
        /// <param name="array2D"></param>
        public static void CountIslands(int[,] array2D)
        {
            bool[][] visited = new bool[array2D.GetLength(0)][];
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                visited[i] = new bool[array2D.GetLength(1)];
            }
            int islandCount = 0;
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    if (array2D[i, j] == 1 && !visited[i][j])
                    {
                        MarkIsland(array2D, visited, i, j);
                        islandCount++;
                    }
                }
            }

            Console.WriteLine(islandCount);
        }

        /// <summary>
        /// Check next value and 3 values below the current row if 1 found iterate it and mark visited.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="visited"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public static void MarkIsland(int[,] matrix, bool[][] visited, int row, int col)
        {
            visited[row][col] = true;
            //Check right to current value
            if (CanMarkMore(matrix, visited, row, col + 1))
            {
                MarkIsland(matrix, visited, row, col + 1);
            }
            for (int i = -1; i < 2; i++)
            {
                //Check for 3 values in the row below.
                if (CanMarkMore(matrix, visited, row + 1, col + i))
                {
                    MarkIsland(matrix, visited, row + 1, col + i);
                }
            }
        }

        /// <summary>
        /// Check if given row and col are in boundry contains '1' and is not visited
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="visited"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static bool CanMarkMore(int[,] matrix, bool[][] visited, int row, int col)
        {
            //Check if in limits and value is 1 and is not visited
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1) && matrix[row, col] == 1 && !visited[row][col])
                return true;
            return false;
        }

        /// <summary>
        /// Get the length of water bodies by counting number of adjacent '0' and print them in ascending order
        /// </summary>
        /// <param name="matrix"></param>
        public static void GetWaterBodiesByLength(int[,] matrix)
        {
            bool[][] visited = new bool[matrix.GetLength(0)][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                visited[i] = new bool[matrix.GetLength(1)];
            }

            List<int> waterBodyCount = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0 && !visited[i][j])
                    {
                        waterBodyCount.Add(MarkWaterBody(matrix, visited, i, j));
                    }
                }
            }
            waterBodyCount.Sort();
            waterBodyCount.ForEach(x => Console.Write(x+" "));
        }

        /// <summary>
        /// Mark visited and count adjacent 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="visited"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static int MarkWaterBody(int[,] matrix, bool[][] visited, int row, int col)
        {
            visited[row][col] = true;
            int waterBodyLength = 1;
            //Check right to current value
            if (CanMarkMoreWater(matrix, visited, row, col + 1))
            {
                waterBodyLength = 1 + MarkWaterBody(matrix, visited, row, col + 1);
            }
            for (int i = -1; i < 2; i++)
            {
                //Check for 3 values in the row below.
                if (CanMarkMoreWater(matrix, visited, row + 1, col + i))
                {
                    waterBodyLength = 1 + MarkWaterBody(matrix, visited, row + 1, col + i);
                }
            }
            return waterBodyLength;
        }

        public static bool CanMarkMoreWater(int[,] matrix, bool[][] visited, int row, int col)
        {
            //Check if in limits and value is 1 and is not visited
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1) && matrix[row, col] == 0 && !visited[row][col])
                return true;
            return false;
        }
    }
}
