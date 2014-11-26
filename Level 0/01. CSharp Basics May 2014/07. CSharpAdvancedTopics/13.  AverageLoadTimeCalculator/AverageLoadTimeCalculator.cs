using System;
using System.Collections.Generic;
using System.Linq;

// We have a report that holds dates, web site URLs and load times (in seconds) in the same format like in the examples below. 
// Your tasks is to calculate the average load time for each URL. Print the URLs in the same order as they first appear in the input report. 
// Print the output in the format given below. Use double floating-point precision. 
// Input format:
// 2014-Mar-02 11:33 http://softuni.bg 8.37725

class AverageLoadTimeCalculator
{
    static void Main()
    {        
        Console.SetWindowSize(80, 40);
        Console.SetBufferSize(80, 1000);
        Console.WriteLine("Enter report line by line. Enter empty line for end of the report:");
        string line = Console.ReadLine().Trim();
        List<KeyValuePair<string, double>> webSites = new List<KeyValuePair<string, double>>();
        List<string> urls = new List<string>();

        while (line != "")
        {
            string[] lineInput = line.Split(' ');
            webSites.Add(new KeyValuePair<string, double>(lineInput[2], double.Parse(lineInput[3])));
            urls.Add(lineInput[2]);
            line = Console.ReadLine().Trim();
        }
    
        urls = urls.Distinct().ToList();

        if (urls.Count == 0)
        {
            Console.WriteLine("Empty report");
        }
        else
        {
            Console.WriteLine("Average load time for each url:");
            foreach (string url in urls)
            {
                double sum = 0;
                int count = 0;
                for (int i = 0; i < webSites.Count; i++)
                {
                    if (webSites[i].Key == url)
                    {
                        sum += webSites[i].Value;
                        count++;
                    }
                }
                Console.WriteLine("{0} -> {1}", url, sum / count);
            }
        }        
    }
}