using System;
using System.Collections.Generic;
using System.Security;

namespace ClearingCommands
{
    public class ClearingCommands
    {
        private static List<char[]> matrix = new List<char[]>();
        private static bool[,] visited;
        private static HashSet<char> commands = new HashSet<char> { '>', 'v', '<', '^'};

        private static int rows;
        private static int cols;

        public static void Main()
        {
            ReadInput();
            CleanMatrix();
            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine("<p>{0}</p>", SecurityElement.Escape(string.Join("", matrix[row])));
            }
        }

        private static void CleanMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    switch (matrix[row][col])
                    {
                        case '>':
                            CleanRight(row, col);
                            break;
                        case 'v':
                            CleanDown(row, col);
                            break;
                        case '<':
                            CleanLeft(row, col);
                            break;
                        case '^':
                            CleanUp(row, col);
                            break;
                    }
                }
            }
        }

        private static void CleanRight(int row, int col)
        {
            if (!visited[row, col])
            {
                visited[row, col] = true;
                col++;

                while (col < cols && !commands.Contains(matrix[row][col]))
                {
                    matrix[row][col] = ' ';
                    col++;
                }
            }
        }

        private static void CleanDown(int row, int col)
        {
            if (!visited[row, col])
            {
                visited[row, col] = true;
                row++;

                while (row < rows && !commands.Contains(matrix[row][col]))
                {
                    matrix[row][col] = ' ';
                    row++;
                }
            }
        }

        private static void CleanLeft(int row, int col)
        {
            if (!visited[row, col])
            {
                visited[row, col] = true;
                col--;

                while (col >= 0 && !commands.Contains(matrix[row][col]))
                {
                    matrix[row][col] = ' ';
                    col--;
                }
            }
        }

        private static void CleanUp(int row, int col)
        {
            if (!visited[row, col])
            {
                visited[row, col] = true;
                row--;

                while (row >= 0 && !commands.Contains(matrix[row][col]))
                {
                    matrix[row][col] = ' ';
                    row--;
                }
            }
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line.Trim() != "END")
            {
                matrix.Add(line.ToCharArray());
                line = Console.ReadLine();
            }

            rows = matrix.Count;
            cols = matrix[0].Length;
            visited = new bool[rows, cols];
        }
    }
}