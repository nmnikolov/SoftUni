using System;
using System.Collections.Generic;
using System.Linq;

//Write a program that takes as input two lists of integers and joins them. The result should hold all numbers from the first list, 
//and all numbers from the second list, without repeating numbers, and arranged in increasing order. The input and output lists are 
//given as integers, separated by a space, each list at a separate line. 
//Examples:
// | Input             | Output            |
// |-------------------|-------------------|
// | 20 40 10 10 30 80 | 10 20 25 30 40 80 |
// | 25 20 40 30 10    |                   |
// |-------------------|-------------------|
// | 5 4 3 2 1         | 1 2 3 4 5 6       |
// | 6 3 2             |                   |
// |-------------------|-------------------|
// | 1                 | 1                 |
// | 1                 |                   |

class JoinLists
{
    static void Main()
    {
        Console.WriteLine("Enter first list of integers on a line, separated by a space:");
        List<string> firstList = new List<string>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        Console.WriteLine("Enter second list of integers on a line, separated by a space:");
        List<string> secondList = new List<string>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

        firstList.AddRange(secondList);
        List<int> numbersList = new List<int>();

        for (int i = 0; i < firstList.Count; i++)
        {
            int n;
            bool nParse = int.TryParse(firstList[i], out n);
            if (!nParse)
            {
                Console.WriteLine("invalid input");
                return;
            }
            numbersList.Add(n);
        }

        numbersList = numbersList.Distinct().ToList();
        numbersList.Sort();
        Console.WriteLine("Output:\n" + string.Join(" ", numbersList));
    }
}
