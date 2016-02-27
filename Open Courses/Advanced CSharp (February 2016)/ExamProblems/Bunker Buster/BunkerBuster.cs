using System;
using System.Collections.Generic;
using System.Linq;

namespace Bunker_Buster
{
    public class BunkerBuster
    {
        private static int rows;
        private static int cols;
        private static int[,] matrix;
        private static int destroyed = 0;
        private static List<AdjacentCell> adjacentCells = new List<AdjacentCell>
        {
            new AdjacentCell { Row = -1, Col = -1},   //up-left
            new AdjacentCell { Row = -1, Col = 0},    //up
            new AdjacentCell { Row = -1, Col = 1},    //up-right
            new AdjacentCell { Row = 0, Col = -1},    //left
            new AdjacentCell { Row = 0, Col = 1},     //right
            new AdjacentCell { Row = 1, Col = -1},    //down-left
            new AdjacentCell { Row = 1, Col = 0},     //down
            new AdjacentCell { Row = 1, Col = 1}      //down-right
        };

        public static void Main()
        {
            ReadInput();
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine("Destroyed bunkers: {0}", destroyed);
            Console.WriteLine("Damage done: {0:F1} %", (destroyed * 100d) / (rows * cols));
        }

        private static void ReadInput()
        {
            int[] dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            rows = dimensions[0];
            cols = dimensions[1];
            matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] line = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            ProcessFires();
        }

        private static void ProcessFires()
        {
            string attackLine = Console.ReadLine();

            while (attackLine != "cease fire!")
            {
                string[] parsedAttack = attackLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int attackRow = int.Parse(parsedAttack[0]);
                int attackCol = int.Parse(parsedAttack[1]);
                int power = parsedAttack[2][0];

                ProcessAttack(attackRow, attackCol, power);
                attackLine = Console.ReadLine();
            }
        }

        private static void ProcessAttack(int row, int col, int power)
        {
            CountDestroyed(matrix[row, col], power);
            matrix[row, col] -= power;

            foreach (AdjacentCell cell in adjacentCells)
            {
                if (IsValidCell(row + cell.Row, col + cell.Col))
                {
                    int halfPower = (int)Math.Ceiling(power / 2d);
                    CountDestroyed(matrix[row + cell.Row, col + cell.Col], halfPower);
                    matrix[row + cell.Row, col + cell.Col] -= halfPower;
                }
            }

        }

        private static void CountDestroyed(int value, int power)
        {
            if (value > 0 && value - power <= 0)
            {
                destroyed++;
            }
        }

        private static bool IsValidCell(int row, int col)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }

    public class AdjacentCell
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}