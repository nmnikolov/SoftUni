using System;

//Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n not divisible by 3 and 7, on a single line, separated by a space. 
//Examples:
// |  n | output       |
// |  3 | 1 2          |
// | 10 | 1 2 4 5 8 10 |

class NotDivisible
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
            if (number % 3 != 0 && number % 7 != 0)
            {
                numbers += number + " ";
            }
            number++;
        }

        Console.WriteLine(numbers.TrimEnd()); //remove white-space characters at the end then print the result
    }
}