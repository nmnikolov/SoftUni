using System;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;

namespace Uppercase_Words
{
    public class UppercaseWords
    {
        public static object SecurytiElement { get; private set; }

        public static void Main()
        {
            Regex regex = new Regex(@"(?<![a-zA-Z])[A-Z]+(?![A-Za-z])");

            string line = Console.ReadLine();

            while (line != "END")
            {
                string output = "";
                int startIndex = 0;

                foreach (Match match in regex.Matches(line))
                {
                    string reversed = match.Value.Reverse();

                    if (reversed == match.Value)
                    {
                        reversed = reversed.Double();
                    }

                    string left = line.Substring(startIndex, Math.Min(match.Index - startIndex, line.Length - 1 - startIndex));
                    var lengt = left.Length;
                    output += left + reversed;
                    startIndex = match.Index + match.Value.Length;
                }

                output += line.Substring(startIndex, line.Length - startIndex);
                Console.WriteLine(SecurityElement.Escape(output));
                line = Console.ReadLine();
            }
        }        
    }

    public static class StringExtensions
    {
        public static string Reverse(this string input)
        {
            return new string(input.ToCharArray().Reverse().ToArray());
        }

        public static string Double(this string input)
        {
            string result = string.Empty;

            foreach (char chr in input)
            {
                result += new string(chr, 2);
            }

            return result;
        }
    }    
}