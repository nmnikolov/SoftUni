using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OlympicsAreComing
{
    public class OlympicsAreComing
    {
        private static string pattern = @"^\s*([^\s]+(?:\s+[^\s]+)*)\s*\|\s*([^\s]+(?:\s+[^\s]+)*)\s*$";
        private static Dictionary<string, HashSet<string>> playersByCountry = new Dictionary<string, HashSet<string>>();
        private static Dictionary<string, int> winsByCountry = new Dictionary<string, int>();

        public static void Main()
        {
            ReadInput();
            PrintResult();
        }

        private static void PrintResult()
        {
            IEnumerable<string> sortedCountries = winsByCountry.OrderByDescending(x => x.Value).Select(x => x.Key);

            foreach (string country in sortedCountries)
            {
                int participants = playersByCountry[country].Count;
                int wins = winsByCountry[country];

                Console.WriteLine("{0} ({1} participants): {2} wins", country, participants, wins);
            }
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line != "report")
            {
                ProcessReportRow(line);
                line = Console.ReadLine();
            }
        }

        private static void ProcessReportRow(string row)
        {
            Match match = Regex.Match(row, pattern);

            string name = match.Groups[1].Value;
            name = Regex.Replace(name, "[\\s]+", " ");
            string country = match.Groups[2].Value;
            country = Regex.Replace(country, "[\\s]+", " ");

            AddData(name, country);
        }

        private static void AddData(string name, string country)
        {
            if (!playersByCountry.ContainsKey(country))
            {
                playersByCountry.Add(country, new HashSet<string>());
                winsByCountry.Add(country, 0);
            }

            playersByCountry[country].Add(name);
            winsByCountry[country]++;
        }
    }
}