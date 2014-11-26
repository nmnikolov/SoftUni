using System;

//Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line. 
//Note that you may need to use a for-loop. 
//Examples:
// | numbers | sum | numbers | sum | number | sum |
// |       3 |	 1 |       5 |   1 |      1 |   1 |
// |         |   2 |         |   2 |        |     |
// |         |   3 |         |   3 |        |     |
// |         |     |         |   4 |        |     |
// |         |     |         |   5 |        |     |

class NumbersToN
{
    static void Main()
    {
        Console.Write("Input number: ");
        int number = int.Parse(Console.ReadLine());
        for (int i = 1; i <= number; i++)
        {
            Console.WriteLine(i);
        }
    }
}