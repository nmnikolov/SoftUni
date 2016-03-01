using System;
using System.Collections;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace SoftuniNumerals
{
    public class SoftuniNumerals
    {
        public static void Main()
        {
            string pattern = @"(aa)|(aba)|(bcc)|(cc)|(cdc)";
            MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern);
            string numeric = ProcessMatches(matches);
            BigInteger number = ConvertToDec(numeric);
            Console.WriteLine(number);
        }

        private static string ProcessMatches(MatchCollection matches)
        {
            string numeric = String.Empty;

            foreach (Match match in matches)
            {
                int digit = match.Groups.Cast<Group>()
                    .Select((v, i) => new { Index = i, Value = v.Value})
                    .Skip(1)
                    .First(o => o.Value != string.Empty)
                    .Index - 1;

                numeric += digit;
            }

            return numeric;
        }

        public static BigInteger ConvertToDec(string numeric)
        {
            BigInteger result = 0;

            for (int index = numeric.Length - 1; index >= 0; index--)
            {
                int digit = int.Parse(numeric[index].ToString());
                result += BigInteger.Pow(5, numeric.Length - 1 - index) * digit;
            }

            return result;
        }
    }
}
