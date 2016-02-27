using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BiggestTableRow
{
    public class BiggestTableRow
    {
        private static Regex regex = new Regex(@"<tr><td>.*<\/td><td>(.*)<\/td><td>(.*)<\/td><td>(.*)<\/td><\/tr>");
        private static double max = double.MinValue;


        public static void Main()
        {
            Console.ReadLine();

            string line = Console.ReadLine();
            List<string> numbers = new List<string>();
            bool isFound = false;

            while (line != "</table>")
            {
                Match match = regex.Match(line);
                double? sum = null;
                List<string> temp = new List<string>();

                if (match.Success)
                {
                    for (int i = 1; i < match.Groups.Count; i++)
                    {
                        double number;
                        bool parse = double.TryParse(match.Groups[i].ToString(), out number);

                        if (parse)
                        {
                            sum = sum == null ? number : sum + number;
                            temp.Add(match.Groups[i].ToString());
                        }
                    }

                    if (sum > max)
                    {
                        max = sum.Value;
                        numbers = temp;
                        isFound = true;
                    }
                }

                line = Console.ReadLine();
            }

            if (isFound)
            {
                Console.WriteLine("{0} = {1}", max, string.Join(" + ", numbers));
            }
            else
            {
                Console.WriteLine("no data");
            }
        }
    }
}