using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveBunnies
{
    public class RadioactiveBunnies
    {
        private static char[,] matrix;
        private static int rows;
        private static int cols;
        private static Position position;
        private static bool[,] visited;
        private static string moves;
        private static string gameOverStatus;
        private static bool gameOver = false;

        private static Dictionary<char, Direction> directions = new Dictionary<char, Direction>
        {
            { 'R', new Direction { Row = 0, Col = 1 } },
            { 'D', new Direction { Row = 1, Col = 0 } },
            { 'L', new Direction { Row = 0, Col = -1 } },
            { 'U', new Direction { Row = -1, Col = 0 } }
        };

        public static void Main()
        {
            ReadInput();
            ProcessMoves();
            PrintResult();
        }

        private static void ProcessMoves()
        {
            foreach (char move in moves)
            {
                matrix[position.Row, position.Col] = '.';
                int newRow = position.Row + directions[move].Row;
                int newCol = position.Col + directions[move].Col;

                if (IsOutSideMatrix(newRow, newCol))
                {
                    gameOver = true;
                    gameOverStatus = Messages.Won;
                }
                else if (matrix[newRow, newCol] == 'B')
                {
                    gameOver = true;
                    gameOverStatus = Messages.Lost;
                    position.Row = newRow;
                    position.Col = newCol;
                }
                else
                {
                    position.Row = newRow;
                    position.Col = newCol;
                    matrix[position.Row, position.Col] = 'P';
                }

                SpreadBunnies();

                if (gameOver)
                {
                    return;
                }

                
            }
        }

        private static void SpreadBunnies()
        {
            List<Position> currentBinnies = new List<Position>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    
                    if (!visited[row, col] && matrix[row, col] == 'B')
                    {
                        currentBinnies.Add(new Position { Row = row, Col = col});
                    }

                    
                }
            }

            foreach (Position bunny in currentBinnies)
            {
                visited[bunny.Row, bunny.Col] = true;

                foreach (KeyValuePair<char, Direction> direction in directions)
                {
                    int newRow = bunny.Row + direction.Value.Row;
                    int newCol = bunny.Col + direction.Value.Col;
                    if (!IsOutSideMatrix(newRow, newCol))
                    {
                        if (matrix[newRow, newCol] == 'P')
                        {
                            gameOver = true;
                            gameOverStatus = Messages.Lost;
                        }

                        matrix[newRow, newCol] = 'B';
                    }
                }
            }
        }

        private static bool IsOutSideMatrix(int row, int col)
        {
            return row < 0 || row == rows || col < 0 || col == cols;
        }

        private static void PrintResult()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("{0}: {1} {2}", gameOverStatus, position.Row, position.Col);
        }

        private static void ReadInput()
        {
            int[] dimension = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            rows = dimension[0];
            cols = dimension[1];

            matrix = new char[rows, cols];
            visited = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];

                    if (matrix[row, col] == 'P')
                    {
                        position = new Position { Row = row, Col = col };
                    }
                }
            }

            moves = Console.ReadLine();
        }
    }

    public class Direction
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }

    public class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }

    public static class Messages
    {
        public const string Won = "won";
        public const string Lost = "dead";
    }
}