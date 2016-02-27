using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace The_Numbers
{
    public class TheNumbers
    {
        private static Regex regex = new Regex(@"[\d]+");
        public static void Main()
        {
            List<string> hex = new List<string>();

            string input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                int number = int.Parse(match.Value);

                string hexValue = number.ToString("X");
                hexValue =  hexValue.PadLeft(4, '0');

                hex.Add("0x" + hexValue);
            }

            Console.WriteLine(string.Join("-", hex));
        }
    }
}