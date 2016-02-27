using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace QueryMess
{
    public class QueryMess
    {
        private static List<string> array = new List<string>();
        private static Dictionary<string, List<string>> output = new Dictionary<string, List<string>>();

        public static void Main()
        {
            ReadInput();

            Regex regex = new Regex(@"[^?&=]+=[^?&=]+");

            foreach (var line in array)
            {
                output.Clear();
                foreach (var match in regex.Matches(line))
                {
                    var row = match.ToString().Split('=');
                    var key = Regex.Replace(row[0], @"(%20|[+])+", " ").Trim();
                    var value = Regex.Replace(row[1], @"(%20|[+])+", " ").Trim();

                    if (!output.ContainsKey(key))
                    {
                        output[key] = new List<string>();
                    }

                    output[key].Add(value);
                }

                Print();
            }
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                array.Add(line);

                line = Console.ReadLine();
            }
        }

        private static void Print()
        {
            foreach (var item in output)
            {
                Console.Write("{0}=[{1}]", item.Key, string.Join(", ", item.Value));
            }
            Console.WriteLine();
        }
    }
}