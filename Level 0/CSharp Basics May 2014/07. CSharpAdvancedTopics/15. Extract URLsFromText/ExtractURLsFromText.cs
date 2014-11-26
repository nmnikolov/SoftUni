using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//Write a program that extracts and prints all URLs from given text. URL can be in only two formats:
//•	http://something, e.g. http://softuni.bg, http://forums.softuni.bg, http://www.nakov.com 
//•	www.something.domain, e.g. www.nakov.com, www.softuni.bg, www.google.com
//Examples:
//
// Input
// The site nakov.com can be access from http://nakov.com or www.nakov.com. It has subdomains like mail.nakov.com and svetlin.nakov.com. Please check http://blog.nakov.com for more information. Please check http://blog.nakov.com for more information.
//
// Output:
// http://nakov.com
// www.nakov.com
// http://blog.nakov.com

class ExtractURLsFromText
{
    static void Main()
    {
        Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));

        Console.WriteLine("Enter text:");
        List<string> text = new List<string>(Console.ReadLine().Split(new char[] { ' ', ',', ';', '!', '"', }, StringSplitOptions.RemoveEmptyEntries));
        List<string> words = new List<string> { "http://", "www." };
        text = text.Where(s => words.Any(w => s.Contains(w))).Distinct().ToList();

        if (text.Count == 0)
        {
            Console.WriteLine("\nno URLs in the text");
            return;
        }

        Console.WriteLine("\nURLs in the text (no duplicates): ");
        foreach (string url in text)
        {
            Console.WriteLine(url.TrimEnd(new char[] { '.' }));
        }      
    }
}
