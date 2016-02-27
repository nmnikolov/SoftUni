using System;
using System.Text.RegularExpressions;

namespace Letters_Change_Numbers
{
    public class LettersChangeNumbers
    {
        public static void Main()
        {
            string pattern = @"\s*([a-zA-Z])+(\d+)([a-zA-Z]+)";

            double sum = 0d;

            MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern);

            foreach (Match match in matches)
            {
                char firstLetter = match.Groups[1].ToString()[0];
                double number = double.Parse(match.Groups[2].ToString());
                char secondLetter = match.Groups[3].ToString()[0];             
                
                if (char.IsUpper(firstLetter))
                {
                    number /= (firstLetter - 64);
                }
                else
                {
                    number *= (firstLetter - 96);
                }

                if (char.IsUpper(secondLetter))
                {
                    number -= (secondLetter - 64);
                }
                else
                {
                    number += (secondLetter - 96);
                }

                sum += number;
            }

            Console.WriteLine("{0:f2}", sum);
        }
    }
}