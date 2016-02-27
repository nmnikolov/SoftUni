using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TextTransformer
{
    public class TextTransformer
    {
        private static StringBuilder text = new StringBuilder();
        private static string pattern = @"(?:(\$)([^$%&']+)\$)|(?:(\%)([^$%&']+)\%)|(?:(\&)([^$%&']+)\&)|(?:(\')([^$%&']+)\')";
        private static StringBuilder output = new StringBuilder();

        public static void Main()
        {
            ReadInput();
            ParseText();
            Console.WriteLine(output);
        }

        private static void ParseText()
        {
            text.Replace("[\\s]+", " ");

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text.ToString());

            foreach (Match match in matches)
            {
                int index = 1;

                while (match.Groups[index].Value == "")
                {
                    index += 2;
                }

                char symbol = match.Groups[index].Value[0];
                int weight = GetWeight(symbol);
                string matchText = match.Groups[index + 1].Value;

                if (output.Length > 0)
                {
                    output.Append(" ");
                }

                foreach (char chr in matchText)
                {
                    output.Append((char)(chr + weight));
                    weight *= -1;
                }
            }
        }

        private static int GetWeight(char symbol)
        {
            return symbol - 35;
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line != "burp")
            {
                text.Append(line);
                line = Console.ReadLine();
            }
        }
    }
}