using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatrixShuffle
{
    public class MatrixShuffle
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            int rows = text.Length / length + (text.Length % length == 0 ? 0 : 1);

            int direction = 1,
                x = 0,
                y = length - 1,
                xCount = rows - 1,
                yCount = length - 1,
                chr = 0;

            List<char[]> temp = new List<char[]>();

            for (int row = 0; row < rows; row++)
            {
                char[] arr = new string('*', length).ToCharArray();

                temp.Add(arr);
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < length; col++)
                {
                    if (row == 0)
                    {
                        temp[row][col] = text[chr++];
                        continue;
                    }

                    for (int i = 0; i < xCount; i++)
                    {
                        x = x + 1 * direction;
                        temp[x][y] = chr < text.Length ? text[chr++] : ' ';
                    }

                    for (int j = 0; j < yCount; j++)
                    {
                        y = y - 1 * direction;
                        temp[x][y] = chr < text.Length ? text[chr++] : ' ';
                    }

                    direction *= -1;
                    xCount--;
                    yCount--;
                }
            }

            string first = "";
            string second = "";

            for (int row = 0; row < temp.Count; row++)
            {
                for (int col = 0; col < length; col += 2)
                {
                    if (row % 2 == 0)
                    {
                        first += temp[row][col];
                        if (col + 1 < temp[row].Length)
                        {
                            second += temp[row][col + 1];
                        }
                    }
                    else
                    {
                        second += temp[row][col];
                        if (col + 1 < temp[row].Length)
                        {
                            first += temp[row][col + 1];
                        }
                    }
                }
            }

            string output = first + second;
            string pol = Regex.Replace(output, @"[^a-zA-Z]", "");
            string color = pol.ToLower() == pol.Reverse().ToLower() ? "#4FE000" : "#E0000F";

            Console.WriteLine("<div style='background-color:{0}'>{1}</div>", color, output);
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