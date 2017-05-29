
using System;

namespace ProblemSolving
{
    public class IslandProblem
    {
        public static void CountIslands(int [,] array2D)
        {
            int islandCount = 0;
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    int currentElement = array2D[i,j];
                    bool isTopWater = i == 0 ? true : (array2D[i - 1,j] == 0 ? true :false);
                    bool isLeftWater = j == 0 ? true : (array2D[i,j - 1] == 0 ? true : false);
                    if (isTopWater && isLeftWater && currentElement == 1)
                    {
                        islandCount++;
                    }
                }
            }

            Console.WriteLine(islandCount);
        }
    }
}
