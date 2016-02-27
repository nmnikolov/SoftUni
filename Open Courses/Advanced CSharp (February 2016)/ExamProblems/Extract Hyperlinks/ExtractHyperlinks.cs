using System;
using System.Text.RegularExpressions;

namespace ExtractHyperlinks
{
    public class ExtractHyperlinks
    {
        private static string input = "";

        public static void Main()
        {
            ReadInput();

            Regex regex = new Regex(@"<a\s[^>]*href\s*=\s*(?:(?:\""([^\"">]+)\"")|(?:\'([^\'>]+)\')|([^>\s]+))*[^>]*>");

            foreach (Match match in regex.Matches(input))
            {
                for (int i = 1; i < match.Groups.Count; i++)
                {
                    if (match.Groups[i].ToString() != "")
                    {
                        Console.WriteLine(match.Groups[i].ToString());
                    }
                }
            }
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                input += line;

                line = Console.ReadLine();
            }
        }
    }
}