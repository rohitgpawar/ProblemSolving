/*
 Group can be diagonal, straight, right,left, down
 1 is group 0 is wall
 eg:
 00001000
 00100001
 01110000
 
 output: 3 Groups

 eg:
 0000001110
 0000000000
 1000010000
 1000000110
 1000000110
 1000100000
 0001000001

 output : 6 groups
 
 */

namespace ProblemSolving
{
    public class GroupAndWall
    {
        public static int GetNumberOfGroups(int [][] array)
        {
            int grpCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[0].Length; j++)
                {
                    bool increaseCount = true;
                    if (array[i][j] == 1)
                    {
                        //Check left
                        if (j > 0 && array[i][j-1] == 1)
                        {
                            increaseCount = false;
                        }
                        //Check top
                        if (i > 0 && (array[i-1][j] == 1 || (j > 0 && array[i - 1][j - 1] == 1) || (j < array.Length - 1 && array[i - 1][j + 1] == 1)))
                        {
                            increaseCount = false;
                        }
                        if (increaseCount)
                        {
                            grpCount++;
                        }
                    }
                }
            }

            return grpCount;
        }

    }
}
