using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Parachute
{
    public class Parachute
    {
        private static List<string> matrix = new List<string>();
        private static Position position;
        private static string message;
        private static bool gameOver = false;

        public static void Main()
        {
            ReadInput();
            FindStartPosition();
            FallDown();
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(message);
            Console.WriteLine("{0} {1}", position.Row, position.Col);
        }

        private static void FallDown()
        { 
            position.Row++;

            while (!gameOver)
            {
                int right = Regex.Matches(matrix[position.Row], @">").Count;
                int left = Regex.Matches(matrix[position.Row], @"<").Count;

                position.Col += right - left;

                switch (matrix[position.Row][position.Col])
                {
                    case '_': message = "Landed on the ground like a boss!"; gameOver = true; break;
                    case '~': message = "Drowned in the water like a cat!"; gameOver = true; break;
                    case '\\': case '/': case '|': message = "Got smacked on the rock like a dog!"; gameOver = true; break;
                    default: position.Row++; break;
                }                
            }
        }

        private static void FindStartPosition()
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'o')
                    {
                        position = new Position {Row = row, Col = col };
                        return;
                    }
                }
            }
        }

        public static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                matrix.Add(line);
                line = Console.ReadLine();
            }
        }
    }

    public class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}