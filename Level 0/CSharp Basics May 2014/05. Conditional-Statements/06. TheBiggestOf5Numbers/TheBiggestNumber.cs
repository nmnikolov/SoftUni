using System;

//Write a program that finds the biggest of five numbers by using only five if statements. Examples:
// |  a |    b |    c |  d |    e | biggest |
// |  5 |    2 |    2 |  4 |    1 |       5 |
// | -2 |  -22 |    1 |  0 |    0 |       1 |
// | -2 |    4 |    3 |  2 |    0 |       4 |
// |  0 | -2.5 |    0 |  5 |    5 |       5 |
// | -3 | -0.5 | -1.1 | -2 | -0.1 |    -0.1 |

class TheBiggestOf5Number
{
    static void Main()
    {
        Console.Write("Input a: "); 
        double a = double.Parse(Console.ReadLine());
        Console.Write("Input b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Input c: ");
        double c = double.Parse(Console.ReadLine());
        Console.Write("Input d: ");
        double d = double.Parse(Console.ReadLine());
        Console.Write("Input e: ");
        double e = double.Parse(Console.ReadLine());

        if (a > b && a > c && a > d && a > e )
        {
            Console.WriteLine("Biggest: {0}", a);
        }
        else if (b > c && b > d && b> e)
        {
            Console.WriteLine("Biggest: {0}", b);
        }
        else if (c > d && c > e)
        {
            Console.WriteLine("Biggest: {0}", c);
        }
        else if (d > e)
        {
            Console.WriteLine("Biggest: {0}", d);
        }
        else
        {
            Console.WriteLine("Biggest: {0}", e);
        }
    }
}