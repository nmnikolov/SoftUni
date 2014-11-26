using System;
using System.Numerics;

//Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence (at a single line, separated by spaces) : 
//0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, …. Note that you may need to learn how to use loops. Examples:
// |  n | comments               |
// |  1 | 0                      |
// |  3 | 0 1 1                  |
// | 10 | 0 1 1 2 3 5 8 13 21 34 |

class FibonacciNumbers
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = Math.Abs(int.Parse(Console.ReadLine()));
        BigInteger x1 = 1;
        BigInteger x2 = 0;
        for (int i = 0; i < number; i++)
        {
            Console.Write("{0} ", x2);
            x2 = x2 + x1;
            x1 = x2 - x1;                           
        }
        Console.WriteLine();
    }
}