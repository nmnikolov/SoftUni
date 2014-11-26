using System;

//Write a program that finds the biggest of three numbers. Examples:
//|    a |    b |    c | biggest |
//|    5 |    2 |    2 |       5 |
//|   -2 |   -2 |    1 |       1 |
//|   -2 |    4 |    3 |       4 |
//|    0 | -2.5 |    5 |       5 |
//| -0.1 | -0.5 | -1.1 |    -0.1 |

class TheBiggestOf3Number
{
    static void Main()
    {
        Console.Write("Input a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Input b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Input c: ");
        double c = double.Parse(Console.ReadLine());

        if (a > b && a > c)
        {
            Console.WriteLine("Biggest: {0}", a);
        }
        else if (b > c)
        {
            Console.WriteLine("Biggest: {0}", b);
        }
        else
        {
            Console.WriteLine("Biggest: {0}", c);
        }
    }
}