using System;
using System.Text.RegularExpressions;

namespace SemanticHTML
{
    public class SemanticHTML
    {
        private static string openTagsPattern = @"(?:<div .*((?:id|class)\s*=\s*""([^ ""]+)"").*>)";
        private static string closeTagsPattern = @"<\/div>\s*<!--\s*([^\s]+)\s*-->";

        public static void Main()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                Match openTagsMatch = Regex.Match(line, openTagsPattern);
                Match closeTagsMatch = Regex.Match(line, closeTagsPattern);

                if (openTagsMatch.Success)
                {
                    line = Regex.Replace(line, openTagsMatch.Groups[1].ToString(), "");
                    line = Regex.Replace(line, "\\s+", " ");
                    line = Regex.Replace(line, "\\s+>", ">");
                    line = Regex.Replace(line, "<div", "<" + openTagsMatch.Groups[2].ToString());
                }

                if (closeTagsMatch.Success)
                {
                    line = Regex.Replace(line, closeTagsMatch.Value, "</" + closeTagsMatch.Groups[1].ToString() + ">");
                }

                Console.WriteLine(line);

                line = Console.ReadLine();
            }
        }
    }
}