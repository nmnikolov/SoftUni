namespace MatrixPaths
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    public class MatrixPaths
    {
        private const char Start = 'S';
        private const char Exit = 'e';
        private const char PassableCell = '_';

        private const char Right = 'R';
        private const char Down = 'D';
        private const char Left = 'L';
        private const char Up = 'U';

        private static int totalPaths = 0;
        private static Matrix matrix;
        private static List<char> path = new List<char>();

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.Layout.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.Layout.GetLength(1);
            return rowInRange && colInRange;
        }

        private static void FindPathToExit(int row, int col, char direction)
        {
            if (!InRange(row, col))
            {
                return;
            }

            path.Add(direction);

            if (matrix.Layout[row, col] == Exit)
            {
                totalPaths++;
                PrintPath(path);
            }

            if (matrix.Layout[row, col] == PassableCell)
            {
                matrix.Layout[row, col] = Start;

                FindPathToExit(row, col - 1, Left);
                FindPathToExit(row - 1, col, Up);
                FindPathToExit(row, col + 1, Right);
                FindPathToExit(row + 1, col, Down);

                matrix.Layout[row, col] = PassableCell;
            }

            path.RemoveAt(path.Count - 1);
        }
        
        private static void PrintPath(List<char> path)
        {
            Console.Write("Found path to the exit: ");
            foreach (var dir in path)
            {
                Console.Write(dir);
            }
            Console.WriteLine();
        }

        private static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            int[] dimensions = ReadMatrixDimensions();

            matrix = new Matrix(dimensions[0], dimensions[1]);
            matrix.PrintLayout();

            var startPoint = ReadStartPointCoordinates();

            FindPathToExit(startPoint.X, startPoint.Y, Start);
            Console.WriteLine("Total paths found: {0}", totalPaths);
        }

        private static int[] ReadMatrixDimensions()
        {
            try
            {
                Console.WriteLine("Enter matrix rows and cols separated by space: ");

                var dimensions = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (dimensions[0] < 1 || dimensions[1] < 1)
                {
                    throw new ArgumentException("Dimensions should be greater than 0.");
                }

                return dimensions;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ReadMatrixDimensions();
            }
        }

        private static Point ReadStartPointCoordinates()
        {
            try
            {
                Console.WriteLine("Enter start point coordinates separated by space: ");
                var startPoint = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                if (matrix.Layout[startPoint[0], startPoint[1]] != PassableCell)
                {
                    throw new InvalidOperationException("Start point can be only empty cell");
                }

                return new Point(startPoint[0], startPoint[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ReadStartPointCoordinates();
            }
        }
    }
}