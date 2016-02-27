using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SrabskoUnleashed
{
    public class SrabskoUnleashed
    {
        private static Dictionary<string, Dictionary<string, int>> venues = new Dictionary<string, Dictionary<string, int>>();


        public static void Main()
        {
            ReadInput();
            PrintResult();
        }

        private static void PrintResult()
        {
            foreach (var venue in venues)
            {
                var sortedSingers = venues[venue.Key].OrderByDescending(s => s.Value).ToList();


                Console.WriteLine(venue.Key);

                foreach (var singer in sortedSingers)
                {
                    Console.WriteLine("#  {0} -> {1}", singer.Key, singer.Value);
                }

            }
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line != "End")
            {
                string pattern = @"(.*)\s{1}@(\D+)\s{1}(\d+)\s{1}(\d+)";

                Match match = Regex.Match(line, pattern);

                if (match.Success)
                {
                    ParseMatch(match);
                }

                line = Console.ReadLine();
            }
        }

        private static void ParseMatch(Match match)
        {
            string singer = match.Groups[1].Value.Trim();
            string venue = match.Groups[2].Value.Trim();
            int price = int.Parse(match.Groups[3].Value);
            int count = int.Parse(match.Groups[4].Value);

            if (!venues.ContainsKey(venue))
            {
                venues[venue] = new Dictionary<string, int>();
            }

            if (!venues[venue].ContainsKey(singer))
            {
                venues[venue][singer] = 0;
            }

            venues[venue][singer] += price * count;
        }
    }
}