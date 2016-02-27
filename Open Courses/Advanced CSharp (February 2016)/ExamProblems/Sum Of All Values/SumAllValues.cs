using System;
using System.Text.RegularExpressions;

namespace SumOfAllValues
{
    public class SumAllValues
    {
        public static void Main()
        {
            bool isFound = false;
            double sum = 0;
            Regex keys = new Regex(@"^([a-zA-Z_]+)\d+(?:.*\d)*([a-zA-Z_]+)$");

            Match keysMatch = keys.Match(Console.ReadLine());

            if (!keysMatch.Success)
            {
                Console.WriteLine("<p>A key is missing</p>");
                return;
            }

            Regex numbersRgx = new Regex(keysMatch.Groups[1].ToString() + "(.+?)" + keysMatch.Groups[2].ToString());

            foreach (Match match in numbersRgx.Matches(Console.ReadLine()))
            {
                double number;
                bool parse = double.TryParse(match.Groups[1].ToString(), out number);
                if (parse)
                {
                    isFound = true;
                    sum += double.Parse(match.Groups[1].ToString());
                }                
            }

            Console.WriteLine("<p>The total value is: <em>{0}</em></p>", isFound ? sum.ToString() : "nothing");
        }
    }
}