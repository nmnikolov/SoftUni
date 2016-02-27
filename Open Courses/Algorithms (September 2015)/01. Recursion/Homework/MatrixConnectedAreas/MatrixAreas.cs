namespace MatrixConnectedAreas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MatrixPaths;

    public class MatrixAreas
    {
        private const char EmptyChar = '-';
        private const char VisitedCell = 'x';

        private static ConsoleColor currentColor;
        private static readonly List<Area> Areas = new List<Area>();
        private static readonly List<string> PassedColors = new List<string>();

        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            int[] dimensions = ReadMatrixDimensions();

            var matrix = new Matrix(dimensions[0], dimensions[1]);
            matrix.PrintLayout();

            FindAllAreas(matrix);
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

        private static void FindAllAreas(Matrix matrix)
        {
            for (int row = 0; row < matrix.Layout.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.Layout.GetLength(1); column++)
                {
                    if (matrix.Layout[row, column] == EmptyChar)
                    {
                        Areas.Add(new Area(column, row));
                        currentColor = GetRandomColor();
                        MeasureArea(matrix, row, column);
                    }
                }
            }

            Console.SetCursorPosition(0, matrix.Layout.GetLength(0) + 1);

            Console.WriteLine("Total areas found: {0}", Areas.Count);
            var results = Areas.OrderByDescending(a => a.Size).ThenBy(a => a.UpLeftRow).ThenBy(a => a.UpLeftColumn).ToArray();
            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine(
                    "Area #{0} at ({1}, {2}), size: {3}",
                    i + 1,
                    results[i].UpLeftRow,
                    results[i].UpLeftColumn,
                    results[i].Size);
            }
        }

        private static void MeasureArea(Matrix matrix, int currentRow, int currentColumn)
        {
            if (currentRow < 0 || currentRow >= matrix.Layout.GetLength(0) || currentColumn < 0 || currentColumn >= matrix.Layout.GetLength(1))
            {
                return;
            }

            if (matrix.Layout[currentRow, currentColumn] != EmptyChar)
            {
                return;
            }

            Areas.Last().IncreaseSize();
            matrix.Layout[currentRow, currentColumn] = VisitedCell;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = currentColor;
            Console.SetCursorPosition(currentColumn, currentRow);
            Console.Write(matrix.Layout[currentRow, currentColumn]);
            Console.ResetColor();

            MeasureArea(matrix, currentRow, currentColumn + 1); 
            MeasureArea(matrix, currentRow + 1, currentColumn); 
            MeasureArea(matrix, currentRow, currentColumn - 1); 
            MeasureArea(matrix, currentRow - 1, currentColumn); 
        }

        private static ConsoleColor GetRandomColor()
        {
            string[] colors = Enum.GetNames(typeof(ConsoleColor));
            string randomColor = colors[(new Random()).Next(colors.Length)];
            while (PassedColors.Contains(randomColor))
            {
                randomColor = colors[(new Random()).Next(colors.Length)];
            }

            PassedColors.Add(randomColor);

            return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), randomColor);
        }
    }
}