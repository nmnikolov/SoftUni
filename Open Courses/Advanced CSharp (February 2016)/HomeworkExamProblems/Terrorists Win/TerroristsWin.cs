using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TerroristsWin
{
    public class TerroristsWin
    {
        public static void Main()
        {
            char symbol = '.';
            string pattern = @"\|(.*?)\|";

            string text = Console.ReadLine();
            StringBuilder input = new StringBuilder(text);

            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                int sum = match.Groups[1].ToString().CharSum();
                int digit = sum % 10;
                input = input.ReplaceWithCharacter(symbol, match.Index - digit, match.Index + match.Length + digit - 1);
            }

            Console.WriteLine(input);
        }
    }

    public static class StringExtensions
    {
        public static StringBuilder ReplaceWithCharacter(this StringBuilder str, char chr, int start, int end)
        {
            start = Math.Max(start, 0);
            end = Math.Min(end, str.Length - 1);

            for (int i = start; i <= end; i++)
            {
                str[i] = chr;
            }

            return str;
        }

        public static int CharSum(this string str)
        {
            int sum = 0;

            foreach (char chr in str)
            {
                sum += chr;
            }

            return sum;
        }
    }
}