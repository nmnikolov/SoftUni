using System;

//Write a program that calculates the greatest common divisor (GCD) of given two integers a and b. Use the Euclidean algorithm (find it in Internet). Examples:
// |  a |   b | GCD(a, b) |
// |  3 |   2 |         1 |
// | 60 |  40 |        20 |
// |  5 | -15 |         5 |

class GreatestCommonDivisor
{
    static void Main()
    {
        Console.Write("Enter integer a: ");
        int a;
        bool aParse = int.TryParse(Console.ReadLine(), out a);
        Console.Write("Enter integer b: ");
        int b;
        bool bParse = int.TryParse(Console.ReadLine(), out b);

        if (!aParse || !bParse)
        {
            Console.WriteLine("invalid input");
            return;
        }

        int reminder = 0;

        while (b != 0)
        {
            reminder = b;
            b = a % b;
            a = reminder;
        }

        Console.WriteLine(Math.Abs(a));
    }
}