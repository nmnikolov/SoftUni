using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LittleJohn
{
    public class LittleJohn
    {
        private static int large = 0;
        private static int medium = 0;
        private static int small = 0;
        
        public static void Main()
        {
            Regex regex = new Regex(@"(>>>----->>)|(>>----->)|(>----->)");

            for (int i = 0; i < 4; i++)
            {
                string line = Console.ReadLine();

                MatchCollection matches = regex.Matches(line);

                foreach (Match match in matches)
                {
                    if (match.Groups[1].ToString() != "")
                    {
                        large++;
                    }
                    else if (match.Groups[2].ToString() != "")
                    {
                        medium++;
                    }
                    else
                    {
                        small++;
                    }
                }
            }

            int number = int.Parse("" + small + medium + large);
            string binary = Convert.ToString(number, 2);
            string reversed = binary.Reverse();

            long reselt = Convert.ToInt64(binary + reversed, 2);
            Console.WriteLine(reselt);
        }
    }

    public static class StringExtensions
    {
        public static string Reverse(this string input)
        {
            return new string(input.ToCharArray().Reverse().ToArray());
        }
    }
}