namespace AreasInMatrix
{
    using System;
    using System.Collections.Generic;

    public class AreasInMatrix
    {
        private static string[] matrix;
        private static bool[,] visited;
        private static SortedDictionary<char, int> areas; 
        private static int rows;
        private static int cols;

        public static void Main()
        {
            ReadMatrix();
            CalculateAreas();
            PrintAreas();
        }

        private static void ReadMatrix()
        {
            var rowsInput = Console.ReadLine().Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
            rows = int.Parse(rowsInput);

            matrix = new string[rows];
            

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine();
            }

            cols = matrix[0].Length;
            visited = new bool[rows, cols];
        }

        private static void CalculateAreas()
        {
            areas = new SortedDictionary<char, int>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!visited[row, col])
                    {
                        if (!areas.ContainsKey(matrix[row][col]))
                        {
                            areas.Add(matrix[row][col], 0);
                        }

                        MeasureArea(row, col, matrix[row][col]);

                        areas[matrix[row][col]]++;
                    }
                }
            }
        }

        private static void MeasureArea(int row, int col, char currLetter)
        {
            if (!IsValidCell(row, col, currLetter))
            {
                return;
            }

            visited[row, col] = true;

            MeasureArea(row - 1, col, currLetter); // UP
            MeasureArea(row, col + 1, currLetter); // RIGHT
            MeasureArea(row + 1, col, currLetter); // DOWN
            MeasureArea(row, col - 1, currLetter); // LEFT

        }

        private static bool IsValidCell(int row, int col, char currLetter)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols && matrix[row][col] == currLetter && !visited[row, col];
        }

        private static void PrintAreas()
        {
            Console.WriteLine("Areas: {0}", areas.Count);
            foreach (var area in areas)
            {
                Console.WriteLine("Letter '{0}' -> {1}", area.Key, area.Value);
            }
        }
    }
}