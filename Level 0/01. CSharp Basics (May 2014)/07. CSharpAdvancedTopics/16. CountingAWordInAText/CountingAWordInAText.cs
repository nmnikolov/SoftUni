using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

//Write a program that counts how many times a given word occurs in given text. The first line in the input holds the word. 
//The second line of the input holds the text. The output should be a single integer number – the number of word occurrences. 
//Matching should be case-insensitive. Note that not all matching substrings are words and should be counted. 
//A word is a sequence of letters separated by punctuation or start / end of text. Examples:

// Input
// hi
// Hidden networks say “Hi” only to Hitachi devices. Hi, said Matuhi. HI!
// Output: 3

// SoftUni
// The Software University (SoftUni) trains software engineers, gives them a profession and a job. Visit us at http://softuni.bg. Enjoy the SoftUnification at SoftUni.BG. Contact us.Email: INFO@SOFTUNI.BG. Facebook: https://www.facebook.com/SoftwareUniversity. YouTube: http://www.youtube.com/SoftwareUniversity. Google+: https://plus.google.com/+SoftuniBg/. Twitter: https://twitter.com/softunibg. GitHub: https://github.com/softuni
// Output: 5
   
// SoftUni
// Software University
// Output: 0
   
// SoftUni
// SoftUni
// Output: 1
   
// SoftUni
// SoftUni.SoftUni
// Output: 2

class CountingAWordInAText
{
    static void Main()
    {
        //Increase Console.ReadLine() buffer size. The default value (254 symbols) is not enough.
        Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));

        Console.WriteLine("Enter a word (case-insensitive) to search in the text:");
        string match = Console.ReadLine().Trim();
        Console.WriteLine("\nEnter text:");
        string text = Console.ReadLine().ToLower();
        List<string> word = new List<string>(text.Split(new char[] { ' ', '.', ',', ';', '!', '"', '(', ')', '@', '/', '“', '”', '\\', '?' }, StringSplitOptions.RemoveEmptyEntries));
        word = word.Where(x => x.ToString().ToLower().Split(',').Where(a => a.Trim() == match.ToLower()).Any()).ToList();
        Console.WriteLine("\n\"{0}\" occurrences: {1}",match , word.Count);
    }
}