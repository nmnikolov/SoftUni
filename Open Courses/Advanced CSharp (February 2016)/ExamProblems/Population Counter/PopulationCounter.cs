using System;
using System.Collections.Generic;
using System.Linq;

namespace PopulationCounter
{
    public class PopulationCounter
    {
        private static Dictionary<string, long> countriesByPopulation = new Dictionary<string, long>();
        private static Dictionary<string, Dictionary<string, int>> citiesByCountry = new Dictionary<string, Dictionary<string, int>>();

        public static void Main()
        {
            ReadInput();
            PrintResult();
        }

        private static void PrintResult()
        {
            IEnumerable<string> countries = countriesByPopulation.OrderByDescending(c => c.Value).Select(c => c.Key);

            foreach (string country in countries)
            {
                Console.WriteLine("{0} (total population: {1})", country, countriesByPopulation[country]);
                IOrderedEnumerable<KeyValuePair<string, int>> sortedCities = citiesByCountry[country].OrderByDescending(c => c.Value);

                foreach (KeyValuePair<string, int> city in sortedCities)
                {
                    Console.WriteLine("=>{0}: {1}", city.Key, city.Value);
                }

            }
        }

        private static void ReadInput()
        {
            string line = Console.ReadLine();

            while (line != "report")
            {
                string[] parameters = line.Split('|');
                string city = parameters[0];
                string country = parameters[1];
                int population = int.Parse(parameters[2]);

                AddRecord(country, city, population);

                line = Console.ReadLine();
            }
        }

        private static void AddRecord(string country, string city, int population)
        {
            if (!countriesByPopulation.ContainsKey(country))
            {
                countriesByPopulation.Add(country, 0);
                citiesByCountry.Add(country, new Dictionary<string, int>());
            }

            countriesByPopulation[country] += population;
            citiesByCountry[country].Add(city, population);
        }
    }
}