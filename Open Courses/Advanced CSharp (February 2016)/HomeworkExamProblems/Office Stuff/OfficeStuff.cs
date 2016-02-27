using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OfficeStuff
{
    public class OfficeStuff
    {
        public static void Main()
        {
            SortedDictionary<string, Dictionary<string, int>> companies = new SortedDictionary<string, Dictionary<string, int>>();

            int rows = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                Match rowData = Regex.Match(Console.ReadLine(), @"\|(.*?) - (\d+) - (.*?)\|");

                string company = rowData.Groups[1].ToString();
                int amount = int.Parse(rowData.Groups[2].ToString());
                string product = rowData.Groups[3].ToString();


                if (!companies.ContainsKey(company))
                {
                    companies[company] = new Dictionary<string, int>();
                }

                if (!companies[company].ContainsKey(product))
                {
                    companies[company][product] = 0;
                }

                companies[company][product] += amount;
            }

            foreach (var company in companies)
            {
                var test = company.Value.Select(c => c.Key + "-" + c.Value);

                Console.WriteLine("{0}: {1}", company.Key, string.Join(", ", test));
            }
        }
    }
}