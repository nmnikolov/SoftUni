using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

//Write a program that reads a list of letters and prints for each letter how many times it appears in the list. 
//The letters should be listed in alphabetical order. Use the input and output format from the examples below. 
//Examples:
// | Input                               | Output |
// |-------------------------------------|--------|
// | b b a a b                           | a -> 2 |
// |                                     | b -> 3 |
// |-------------------------------------|--------|
// | h d h a a a s d f d a d j d s h a a | a -> 6 |
// |                                     | d -> 5 |
// |                                     | f -> 1 |
// |                                     | h -> 3 |
// |                                     | j -> 1 |
// |                                     | s -> 2 |

class CountLetters
{
    static void Main()
    {
        Console.WriteLine("Enter list of letters (case-insensitive) on a line, separated by a space:");
        string input = string.Join("", Console.ReadLine().ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        List<char> uniqueLetters = input.Distinct().OrderBy(x => x).ToList();
        
        if (!Regex.IsMatch(input, @"^[a-z ]+$"))
        {
            Console.WriteLine("The list must contain only letters or no letters entered.");
            return;
        }       

        foreach (char c in uniqueLetters)
        {
            Console.WriteLine("{0} -> {1}", c, input.Count(x => x == c));
        }       
    }
}