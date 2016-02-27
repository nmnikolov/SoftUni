namespace MatrixPaths
{
    using System;

    public class Matrix
    {
        private const char PassableCell = '_';
        private const char NonPassableCell = '*';
        private const char Exit = 'e';

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

            var randRow = rnd.Next(0, this.Rows);
            var randCol = rnd.Next(0, this.Cols);
            this.Layout[randRow, randCol] = Exit;
        }

        public void PrintLayout()
        {
            this.PrintColumnsLegend();
            var pad = this.Cols.ToString().Length + 1;

            Console.WriteLine(
                new string(' ', 
                this.Rows.ToString().Length) + 
                " ╒" + 
                new string('═', (this.Cols * (this.Cols.ToString().Length + 1)) + this.Cols.ToString().Length) + 
                '╕');
             
            for (int row = 0; row < this.Rows; row++)
            {

                Console.Write("{0}{1} │", row, new string(' ', this.Rows.ToString().Length - row.ToString().Length));
                for (int col = 0; col < this.Cols; col++)
                {
                    Console.Write(this.Layout[row, col].ToString().PadLeft(pad, ' '));
                }

                Console.WriteLine(('│').ToString().PadLeft(pad, ' '));
            }

            Console.WriteLine(
                new string(' ', this.Rows.ToString().Length) + 
                " ╘" + 
                new string('═', (this.Cols * (this.Cols.ToString().Length + 1)) + this.Cols.ToString().Length) 
                + '╛');
        }

        public void PrintColumnsLegend()
        {
            var pad = this.Cols.ToString().Length + 1;

            Console.Write(new string(' ', this.Rows.ToString().Length + 2));
            for (int cols = 0; cols < this.Cols; cols++)
            {
                Console.Write(cols.ToString().PadLeft(pad, ' '), cols);
            }
            Console.WriteLine();
        }
    }
}