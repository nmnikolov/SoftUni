using System;
using System.Collections.Generic;
using System.Linq;

//Write a program that takes as input two lists of names and removes from the first list all names given in the second list. The input and output lists are given as words, separated by a space, each list at a separate line. Examples:
// | Input	                                  | Output                 | 
// |------------------------------------------|------------------------|
// | Peter Alex Maria Todor Steve Diana Steve | Peter Alex Maria Diana |
// | Todor Steve Nakov                        |                        |
// |------------------------------------------|------------------------|
// | Hristo Hristo Nakov Nakov Petya          | Hristo Hristo Petya    |
// | Nakov Vanessa Maria                      |                        |

class RemoveNames
{
    static void Main()
    {
        Console.WriteLine("Enter list of names on a line, separated by a space:");
        List<string> firstList = new List<string>(Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries));
        Console.WriteLine("Enter names to remove on a line, separated by a space:");
        List<string> secondList = new List<string>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

        for (int i = 0; i < secondList.Count; i++)
        {
            firstList.RemoveAll(item => item == secondList[i]);
        }

        Console.WriteLine("Output:\n" + string.Join(" ", firstList));
    }
}