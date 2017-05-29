/*
 Given N*M matrix write a method to rotate the matrix by 90 Degree.
 */

using System;

namespace ProblemSolving
{
    public class RotateMatrix
    {
        public static void GetRotateMatrix()
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[3];
            matrix[0][0] = 00;
            matrix[0][1] = 01;
            matrix[0][2] = 02;
            matrix[1] = new int[3];
            matrix[1][0] = 10;
            matrix[1][1] = 11;
            matrix[1][2] = 12;
            matrix[2] = new int[3];
            matrix[2][0] = 20;
            matrix[2][1] = 21;
            matrix[2][2] = 22;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i][j].ToString());
                }
                Console.WriteLine();
            }
            Console.WriteLine("Rotated Matrix");

            // NOT IN PLACE ROTATION
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 2; j >= 0; j--)
            //    {
            //        Console.Write(matrix[j,i]);
            //    }
            //    Console.WriteLine();
            //}

            // ROTATION IN PLACE
            if (matrix.Length == 0 || matrix.Length != matrix[0].Length)
            {
                //return false;
            }
            int size = matrix.Length;

            for (int i = 0; i < size / 2; i++)
            {
                int first = i;
                int last = size - 1 - i;
                for (int j = first; j < last; j++)
                {
                    int offset = j - first;
                    int top = matrix[first][j];
                    matrix[first][j] = matrix[last - offset][first];
                    matrix[last - offset][first] = matrix[last][last - offset];
                    matrix[last][last - offset] = matrix[j][last];
                    matrix[j][last] = top;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i][j].ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
