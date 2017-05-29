/*/
 If matrix contains 0 entire row and column should be set to 0;
 */
using System;

namespace ProblemSolving
{
    public class ZeroMatrix
    {
        public static void SetZeroMatrix()
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[3];
            matrix[0][0] = 100;
            matrix[0][1] = 01;
            matrix[0][2] = 02;
            matrix[1] = new int[3];
            matrix[1][0] = 10;
            matrix[1][1] = 11;
            matrix[1][2] = 12;
            matrix[2] = new int[3];
            matrix[2][0] = 20;
            matrix[2][1] = 0;
            matrix[2][2] = 22;
            printMatrix(matrix);
            Console.WriteLine("Zero Matrix");
            bool[] rows = new bool[matrix.Length];
            bool[] cols = new bool[matrix.Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rows[i] = true;
                        cols[j] = true;
                    }
                }
            }
            //Nullify Rows
            for (int i = 0; i < matrix.Length; i++)
            {
                if (rows[i])
                {
                    for (int n = 0; n < matrix.Length; n++)
                    {
                        matrix[i][n] = 0;
                    }
                }
            }
            //Nullify Cols
            for (int i = 0; i < matrix.Length; i++)
            {
                if (cols[i])
                {
                    for (int n = 0; n < matrix.Length; n++)
                    {
                        matrix[n][i] = 0;
                    }
                }
            }
            printMatrix(matrix);
        }

        public static void printMatrix(int [][] matrix)
        {
            int size = matrix.Length;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i][j]+"\t");
                }
                Console.WriteLine();
            }
        }
    }
}
