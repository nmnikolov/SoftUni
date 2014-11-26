using System;

//Write a program that gets two numbers from the console and prints the greater of them. Try to implement this without if statements. Examples:
// |   a |   b | greater |
// |   5 |   6 |       6 |
// |  10 |   5 |      10 |
// |   0 |   0 |       0 |
// |  -5 |  -2 |      -2 |
// | 1.5 | 1.6 |     1.6 |

class NumberComparer
{
    static void Main()
    {
        Console.Write("Input number a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Input number b: ");
        double b = double.Parse(Console.ReadLine());
        double greater = a >= b ? a : b;
        Console.WriteLine("greater: {0}", greater);

        //Second method using Math.Max
        Console.WriteLine("greater(using Math.Max): {0}", Math.Max(a, b));        
    }
}