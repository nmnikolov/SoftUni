using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RageQuit
{
    public class RageQuit
    {
        private static string pattern = @"([^\d]+)(\d+)";

        public static void Main()
        {
            string line = Console.ReadLine();

            MatchCollection matches = Regex.Matches(line, pattern);
            StringBuilder output = new StringBuilder();

            foreach (Match match in matches)
            {
                string sequence = match.Groups[1].Value.ToUpper();
                int repeat = int.Parse(match.Groups[2].Value);

                for (int i = 0; i < repeat; i++)
                {
                    output.Append(sequence);
                }
            }

            Console.WriteLine("Unique symbols used: {0}", output.ToString().Distinct().Count());
            Console.WriteLine(output);
        }
    }
}