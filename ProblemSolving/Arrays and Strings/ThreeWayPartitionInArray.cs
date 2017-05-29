/*
 There are 3 kinds of balls in a big array. Red, Green, Blue color balls. 
 Arrange them in such a way that all the red balls to the left, Green balls in the middle and Blue balls to the right of the array.
 */

using System;

namespace ProblemSolving
{
    public class ThreeWayPartitionInArray
    {
        public static void Partition3wayInArray(char[] arry)
        {

            int red = 0;
            int compare = 0;
            int blue = arry.Length - 1;
            while (compare <= blue)
            {
                if (arry[compare] == 'R')
                {
                    char temp = arry[red];
                    arry[red] = arry[compare];
                    arry[compare] = temp;
                    red++;
                    compare++;
                }
                else if (arry[compare] == 'B')
                {
                    char tmp = arry[blue];
                    arry[blue] = arry[compare];
                    arry[compare] = tmp;
                    blue = blue - 1;

                }
                else
                {
                    compare++;
                }
            }

            for (int i = 0; i < arry.Length; i++)
            {
                Console.Write(" {0} ", arry[i]);
            }
        }

        public static void PartitionRGBInArray(char[] arry)
        {

            int red = 0;
            int compare = 0;
            int green = 1;
            int blue = 2;
            while (compare < arry.Length&& red< arry.Length && blue < arry.Length && green < arry.Length)
            {
                if (arry[compare] == 'R')
                {
                    if (compare == red && arry[red] == arry[compare])
                    {
                        compare++;
                        red = red + 3;
                    }
                    else
                    {
                        char temp = arry[red];
                        arry[red] = arry[compare];
                        arry[compare] = temp;
                    }
                }
                else if (arry[compare] == 'B')
                {
                    if (compare == blue && arry[blue] == arry[compare])
                    {
                        compare++;
                        blue = blue + 3;
                    }
                    else
                    {
                        char tmp = arry[blue];
                        arry[blue] = arry[compare];
                        arry[compare] = tmp;
                    }
                }
                else
                {
                    if (compare == green && arry[green] == arry[compare])
                    {
                        compare++;
                        green = green + 3;
                    }
                    else
                    {
                        char tmp = arry[green];
                        arry[green] = arry[compare];
                        arry[compare] = tmp;
                    }
                }
            }

            for (int i = 0; i < arry.Length; i++)
            {
                Console.Write(" {0} ", arry[i]);
            }
        }
    }
}
