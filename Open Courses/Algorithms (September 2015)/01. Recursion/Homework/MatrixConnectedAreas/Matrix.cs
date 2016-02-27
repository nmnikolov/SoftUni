namespace MatrixPaths
{
    using System;

    public class Matrix
    {
        private const char PassableCell = '-';
        private const char NonPassableCell = '*';

        private static readonly char[] PossibleCellValues = { PassableCell, PassableCell, NonPassableCell};
        private static readonly Random rnd = new Random();

        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.Layout = new char[rows, cols];
            this.GenerateLayout();
        }

        public int Rows { get; set; }

        public int Cols { get; set; }

        public char[,] Layout { get; set; }

        private void GenerateLayout()
        {
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    var index = rnd.Next(0, PossibleCellValues.Length);
                    this.Layout[row, col] = PossibleCellValues[index];
                }
            }
        }

        public void PrintLayout()
        {
            Console.Clear();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    Console.Write(this.Layout[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}