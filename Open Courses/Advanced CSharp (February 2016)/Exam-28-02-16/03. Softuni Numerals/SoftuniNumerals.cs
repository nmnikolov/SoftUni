using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _03.Softuni_Numerals
{
    public class SoftuniNumerals
    {
        public static void Main()
        {
            string pattern = @"aa|aba|bcc|cc|cdc";
            MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern);
            string numeric = String.Empty;

            foreach (Match match in matches)
            {
                switch (match.Value)
                {
                    case "aa":
                        numeric += "0";
                        break;
                    case "aba":
                        numeric += "1";
                        break;
                    case "bcc":
                        numeric += "2";
                        break;
                    case "cc":
                        numeric += "3";
                        break;
                    case "cdc":
                        numeric += "4";
                        break;
                }
            }

            BigInteger number = ConvertToDec(numeric);
            Console.WriteLine(number);
        }

        public static BigInteger ConvertToDec(string numeric)
        {
            BigInteger result = 0;
            numeric = new string(numeric.ToCharArray().Reverse().ToArray());

            for (int i = 0; i < numeric.Length; i++)
            {
                int digit = int.Parse(numeric[i].ToString());

                if (i == 0)
                {
                    result += digit;
                }
                else
                {
                    BigInteger pow = 5;

                    for (int j = 1; j < i; j++)
                    {
                        pow *= 5;
                    }
                    
                    result += pow * digit;
                }
            }

            return result;
        }
    }
}