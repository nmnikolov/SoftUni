using System;
using System.Security;

namespace TextGravity
{
    public class TextGravity
    {
        private static int cols;
        private static int rows;
        private static char[,] matrix;

        public static void Main()
        {
            cols = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();            
            rows = input.Length / cols + (input.Length % cols == 0 ? 0 : 1);

            FillMatrix(input);
            SeedMatrix();
            PrintMatrix();
        }

        private static void SeedMatrix()
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

        private static void PrintMatrix()
        {
            Console.Write("<table>");

            for (int row = 0; row < rows; row++)
            {
                Console.Write("<tr>");
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("<td>{0}</td>", SecurityElement.Escape(matrix[row, col].ToString()));
                }

                Console.Write("</tr>");
            }

            Console.Write("</table>");
        }

        public static void FillMatrix(string input)
        {
            matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int index = row * cols + col;

                    if (index < input.Length)
                    {
                        matrix[row, col] = input[index];
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }
    }
}