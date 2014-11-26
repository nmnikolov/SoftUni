using System;

//Write a program to find the longest area of equal elements in array of strings. You first should read an integer n and n strings 
//(each at a separate line), then find and print the longest sequence of equal elements (first its length, then its elements). 
//If multiple sequences have the same maximal length, print the leftmost of them. Examples:
//
// | Input   | Output  |    | Input | Output |    | Input | Output |    | Input   | Output  | 
// |---------|---------|    |-------|--------|    |-------|--------|    |---------|---------|
// | 6       | 3       |    | 5     | 2      |    | 4     | 4      |    | 2       | 1       |
// | hi      | ok      |    | wow   | hi     |    | hi    | hi     |    | SoftUni | SoftUni |
// | hi      | ok      |    | hi    | hi     |    | hi    | hi     |    | Hello   |         |
// | hello   | ok      |    | hi    |        |    | hi    | hi     |
// | ok      |         |    | ok    |        |    | hi    | hi     |
// | ok      |         |    | ok    |        |
// | ok      |         |

class LongestAreaInArray
{
    static void Main()
    {
        Console.Write("Elements to read: ");
        int n;
        bool nParse = int.TryParse(Console.ReadLine(), out n);

        if (!nParse || n < 1)
        {
            Console.WriteLine("invalid input");
            return;
        }

        string[] elementsArray = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element [{0}]: ", i + 1);
            elementsArray[i] = Console.ReadLine();
        }
        
        string value = elementsArray[0];
        int count = 1;     
        int tempCount = 0;

        for (int i = 1; i < n; i++)
        {
            if (elementsArray[i] == elementsArray[i - 1] && tempCount == 0)
            {
                count++;
            }
            if (elementsArray[i] == elementsArray[i - 1] && tempCount > 0)
            {                
                tempCount++;
            }
            if (elementsArray[i] != elementsArray[i - 1])
            {
                tempCount = 1;
            }
            if (tempCount > count)
            {
                value = elementsArray[i];
                count = tempCount;
                tempCount = 0;
            }
        }

        Console.WriteLine("\nOutput:");
        Console.WriteLine(count);

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(value);
        }
    }
}
