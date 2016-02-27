using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
{
    public class TargetPractice
    {
        private static int rows;
        private static int cols;
        private static string word;
        private static Shot shot;
        private static char[,] matrix;
        private static int index;
        private static int direction = -1;

        public static void Main()
        {
            ReadInput();
            FillMatrix();
            Shoot();
            MoveDown();
            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void MoveDown()
        {
            for (int row = rows - 2; row >= 0; row--)
            {
                for (int col = 0; col < cols; col++)
                {
                    for (int i = row; i < rows - 1; i++)
                    {
                        if (matrix[i + 1, col] == ' ')
                        {
                            matrix[i + 1, col] = matrix[i, col];
                            matrix[i, col] = ' ';
                        }
                    }
                }
            }
        }

        private static void Shoot()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (IsInsideCurcle(row, col))
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static bool IsInsideCurcle(int row, int col)
        {
            return ((row - shot.Row) * (row - shot.Row) + (col - shot.Col) * (col - shot.Col)) <= shot.Impact * shot.Impact;
        }

        private static void FillMatrix()
        {
            matrix = new char[rows, cols];
            index = 0;

            for (int row = rows - 1; row >= 0; row--)
            {
                if (direction == -1)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = word[index];
                        ChangeIndex();
                    }
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = word[index];
                        ChangeIndex();
                    }
                }

                direction *= -1;
            }


            
        }

        private static void ChangeIndex()
        {
            index = ++index % word.Length;
        }

        private static void ReadInput()
        {
            int[] matrixDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            rows = matrixDimensions[0];
            cols = matrixDimensions[1];

            word = Console.ReadLine();

            int[] shotParams = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            shot = new Shot { Row = shotParams[0], Col = shotParams[1], Impact = shotParams[2] };
        }
    }

    public class Shot
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Impact { get; set; }
    }
}