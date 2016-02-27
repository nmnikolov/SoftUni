using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ShmoogleCounter
{
    public class ShmoogleCounter
    {
        private static Dictionary<string, List<string>> variables = new Dictionary<string, List<string>>
        {
            { "double", new List<string>() },
            { "int", new List<string>() }
        };

        public static void Main()
        {
            ReadInput();
            PrintResult();
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line != "//END_OF_CODE")
            {
                string pattern = @"(double|int)\s+([a-z][a-zA-z]*)";

                MatchCollection matches = Regex.Matches(line, pattern);

                foreach (Match match in matches)
                {
                    string type = match.Groups[1].Value;
                    string variable = match.Groups[2].Value;
                    variables[type].Add(variable);
                }

                line = Console.ReadLine();
            }
        }

        private static void PrintResult()
        {
            List<string> sortedDoubles = variables["double"].OrderBy(o => o).ToList();
            List<string> sortedInts = variables["int"].OrderBy(o => o).ToList();

            string doublesResult = sortedDoubles.Count > 0 ? string.Join(", ", sortedDoubles) : "None";
            string intsResult = sortedInts.Count > 0 ? string.Join(", ", sortedInts) : "None";

            Console.WriteLine("Doubles: {0}", doublesResult);
            Console.WriteLine("Ints: {0}", intsResult);
        }
    }
}