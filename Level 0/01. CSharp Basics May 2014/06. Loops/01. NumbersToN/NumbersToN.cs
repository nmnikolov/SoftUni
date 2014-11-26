using System;

//Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n, on a single line, separated by a space. Examples:
// | n | output    |
// | 3 | 1 2 3     |
// | 5 | 1 2 3 4 5 |

class NumbersToN
{
    static void Main()
    {
        Console.Write("Enter integer number (1 <= n): ");
        int n;
        bool nParse = int.TryParse(Console.ReadLine(), out n);

        if (!nParse || n < 1)
        {
            Console.WriteLine("invalid number");
            return;
        }

        int number = 1;
        string numbers = "";

        while (number <= n)
        {            
            numbers += number + " ";  
            number++;
        }

        Console.WriteLine(numbers.TrimEnd()); //remove white-space characters at the end then print the result
    }
}
