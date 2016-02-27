using System;
using System.Collections.Generic;
using System.Linq;

namespace ITVillage
{
    public class ITVillage
    {
        private static string[,] matrix = new string[4, 4];
        private static Position currentPosition;
        private static int currentDirection;
        private static int[] moves;
        private static int currentMove;
        private static int coins = 50;
        private static HashSet<string> ownInns = new HashSet<string>();
        private static int myIns = 0;
        private static int totalIns = 0;
        private static string previousField = "";

        private static string gameOverMessage;

        private static Position[] directions = new Position[] 
        {
            new Position { Row = 0, Col = 1}, // right,
            new Position { Row = 1, Col = 0}, // down,
            new Position { Row = 0, Col = -1}, // left,
            new Position { Row = -1, Col = 0}, // up
        };

        public static void Main()
        {
            ReadInput();
            ReadStartPosition();
            FindCurrentDirection();
            ReadMoves();
            ProcessMoves();
            PrintResult();
        }

        private static void PrintResult()
        {
            if (gameOverMessage == Messages.LostOutOfMoney || gameOverMessage == Messages.WonNakovField)
            {
                Console.WriteLine(gameOverMessage);
            }
            else if(gameOverMessage == null)
            {
                Console.WriteLine(Messages.LostOutOfMoves, coins);
            }
            else
            {
                Console.WriteLine(gameOverMessage, coins);
            }
        }

        private static void ProcessMoves()
        {
            for (currentMove = 0; currentMove < moves.Length; currentMove++)
            {
                if (previousField != "S")
                {
                    coins += myIns * 20;
                }

                for (int i = 0; i < moves[currentMove]; i++)
                {
                    if (!IsValidMove(currentPosition.Row + directions[currentDirection].Row) || 
                        !IsValidMove(currentPosition.Col + directions[currentDirection].Col))
                    {
                        ChangeDirection();
                    }

                    currentPosition.Row += directions[currentDirection].Row;
                    currentPosition.Col += directions[currentDirection].Col;
                }

                ProcessBoardField(matrix[currentPosition.Row, currentPosition.Col]);
            }
        }

        private static void ProcessBoardField(string field)
        {
            switch (field)
            {
                case "P":
                    coins -= 5;
                    CheckEnoughCoins();
                    break;
                case "I":
                    ProcessInnField();
                    break;
                case "F":
                    coins += 20; break;
                case "S":
                    currentMove += 2; break;                
                case "V":
                    coins *= 10; break;
                case "N":
                    gameOverMessage = Messages.WonNakovField;
                    currentMove = moves.Length;
                    break;
            }

            previousField = field;          
        }

        private static void CheckEnoughCoins()
        {
            if (coins < 0)
            {
                gameOverMessage = Messages.LostOutOfMoney;
                currentMove = moves.Length;
            }
        }

        private static void ProcessInnField()
        {
            string index = "" + currentPosition.Row + "|" + currentPosition.Col;

            if (coins >= 100)
            {
                coins -= 100;
                myIns++;
            }
            else
            {
                coins -= 10;
            }

            if (myIns == totalIns)
            {
                gameOverMessage = Messages.WonBoughtAllInns;
                currentMove = moves.Length;
            }

            CheckEnoughCoins();
        }

        private static void ReadMoves()
        {
            moves = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        private static void ChangeDirection()
        {
            currentDirection = (currentDirection + 1) % 4;
        }

        private static void ReadStartPosition()
        {
            IEnumerable<int> input = Console.ReadLine().Split(' ').Select(int.Parse);
            currentPosition = new Position
            {
                Row = input.First() - 1,
                Col = input.Last() - 1
            };
        }

        private static void ReadInput()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '|'}, StringSplitOptions.RemoveEmptyEntries);
            int index = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[index];
                    if (input[index] == "I")
                    {
                        totalIns++;
                    }

                    index++;
                }
            }
        }

        private static void FindCurrentDirection()
        {
            if (currentPosition.Row == 0 && currentPosition.Col < 3)
            {
                currentDirection = 0;
            }
            else if (currentPosition.Col == 3 && currentPosition.Row < 3)
            {
                currentDirection = 1;
            }
            else if (currentPosition.Row == 3 && currentPosition.Col > 0)
            {
                currentDirection = 2;
            }
            else if (currentPosition.Col == 0 && currentPosition.Row > 0)
            {
                currentDirection = 3;
            }
        }

        private static bool IsValidMove(int index)
        {
            return index >= 0 && index <= 3;
        }
    }

    public class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }

    public static class Messages
    {
        public const string LostOutOfMoney = "<p>You lost! You ran out of money!<p>";
        public const string WonBoughtAllInns = "<p>You won! You own the village now! You have {0} coins!<p>";
        public const string LostOutOfMoves = "<p>You lost! No more moves! You have {0} coins!<p>";
        public const string WonNakovField = "<p>You won! Nakov's force was with you!<p>";
    }
}