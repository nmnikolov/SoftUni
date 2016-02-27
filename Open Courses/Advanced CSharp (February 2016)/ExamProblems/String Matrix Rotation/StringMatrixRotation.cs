using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringMatrixRotation
{  
    public class StringMatrixRotation
    {
        private static List<string> array = new List<string>();
        private static int degrees;
        private static List<string> matrix = new List<string>();
        private static int longest = 0;

        public static void Main()
        {
            degrees = int.Parse(Regex.Replace(Console.ReadLine(), @"[^0-9]+", "")) % 360;
            
            ReadInput();

            for (var i = 0; i < array.Count; i++)
            {
                longest = Math.Max(longest, array[i].Length);
            }

            switch (degrees)
            {
                case 0: matrix = array; break;
                case 90: Rotate90(); break;
                case 180: Rotate180(); break;
                case 270: Rotate270(); break;
            }

            Console.WriteLine(string.Join("\n", matrix));
        }

        private static void Rotate270()
        {
            Rotate90();
            matrix.Reverse();
            for (var i = 0; i < matrix.Count; i++)
            {
                matrix[i] = matrix[i].Reverse();
            }
        }

        private static void Rotate180()
        {
            for (var row = array.Count - 1; row >= 0; row--)
            {
                string reversed = array[row].Reverse();

                while (reversed.Length < longest)
                {
                    reversed = ' ' + reversed;
                }
                matrix.Add(reversed);
            }
        }

        private static void Rotate90()
        {
            for (var col = 0; col < longest; col++)
            {
                string temp = "";
                for (var row = array.Count - 1; row >= 0; row--)
                {
                    if (col < array[row].Length)
                    {
                        temp += array[row][col];
                    }
                    else {
                        temp += " ";
                    }
                }
                matrix.Add(temp);
            }
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                array.Add(line);

                line = Console.ReadLine();
            }
        }
    }

    public static class StringExtensions
    {
        public static string Reverse(this string input)
        {
            return new string(input.ToCharArray().Reverse().ToArray());
        }
    }
}