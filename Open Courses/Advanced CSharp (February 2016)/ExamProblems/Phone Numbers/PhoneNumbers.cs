using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PhoneNumbers
{
    public class PhoneNumbers
    {
        private static Regex regex = new Regex(@"([A-Z][A-Za-z]*)[^+a-zA-Z]*?(\+?\d[\d()\/\.\-\s]+)");
        private static List<KeyValuePair<string, string>> output = new List<KeyValuePair<string, string>>();
        private static string inputData = string.Empty;

        public static void Main()
        {
            ReadInput();            

            MatchCollection matches = regex.Matches(inputData);
            PrintMatches(matches);

            
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                inputData += line;
                line = Console.ReadLine();
            }
        }

        private static void PrintMatches(MatchCollection matches)
        {
            if (matches.Count == 0)
            {
                Console.WriteLine("<p>No matches!</p>");
                return;
            }

            Console.Write("<ol>");

            foreach (Match match in matches)
            {
                string name = match.Groups[1].ToString();
                string number = Regex.Replace(match.Groups[2].ToString(), @"[()\/\.\-\s]", "");

                Console.Write("<li><b>{0}:</b> {1}</li>", name, number);
            }

            Console.Write("</ol>");
        }
    }
}