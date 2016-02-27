using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Wintellect.PowerCollections;

namespace ActivityTracker
{
    public class ActivityTracker
    {
        public static void Main()
        {
            OrderedDictionary<int, OrderedDictionary<string, double>> result = new OrderedDictionary<int, OrderedDictionary<string, double>>();

            int rows = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                string[] row = Console.ReadLine().Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);

                DateTime date = DateTime.ParseExact(row[0], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string name = row[1];
                double distance = double.Parse(row[2]);

                if (!result.ContainsKey(date.Month))
                {
                    result[date.Month] = new OrderedDictionary<string, double>();
                }

                if (!result[date.Month].ContainsKey(name))
                {
                    result[date.Month][name] = 0d;
                }

                result[date.Month][name] += distance;
            }

            foreach (var month in result)
            {
                var test = month.Value.Select(x => string.Format("{0}({1})", x.Key, x.Value));

                Console.WriteLine("{0}: {1}", month.Key, string.Join(", ", test));

            }
        }
    }
}