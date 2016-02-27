using System;
using System.Text.RegularExpressions;

namespace ValidUsernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            int max = int.MinValue;
            string first = string.Empty;
            string second = string.Empty;

            string pattern = @"(?<=^|[\s\\\/\(\)])([a-zA-Z][a-zA-Z_\d]{2,24})(?=$|[\s\\\/\(\)])";

            MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern);

            for (int i = 0; i < matches.Count - 1; i++)
            {
                int length = matches[i].Length + matches[i + 1].Length;
                if (length > max)
                {
                    max = length;
                    first = matches[i].Value;
                    second = matches[i + 1].Value;
                }
            }

            Console.WriteLine(first);
            Console.WriteLine(second);
        }
    }
}