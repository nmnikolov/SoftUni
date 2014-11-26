using System;

//Write a program that enters 3 real numbers and prints them sorted in descending order. Use nested if statements. 
//Don’t use arrays and the built-in sorting functionality. Examples:
// |    a |    b |    c |         result |
// |    5 |    1 |    2 |    5    2    1 |
// |   -2 |   -2 |    1 |    1   -2   -2 |
// |   -2 |    4 |    3 |    4    3   -2 |
// |    0 | -2.5 |    5 |    5    0 -2.5 |
// | -1.1 | -0.5 | -0.1 | -0.1 -0.5 -1.1 |
// |   10 |	  20 |	 30 |   30   20   10 |
// |    1 |    1 |	  1 |    1    1    1 |

class Sort3Numbers
{
    static void Main()
    {
        Console.Write("Input a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Input b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Input c: ");
        double c = double.Parse(Console.ReadLine());

        double max;
        double middle;
        double min;

        if (a >= b && a >= c)
        {
            max = a;
            middle = b >= c ? b : c;
            min = c < b ? c : b;
        }
        else if (b >= c)
        {
            max = b;
            middle = a >= c ? a : c;
            min = c < a ? c : a;
        }
        else
        {
            max = c;
            middle = a >= b ? a : b;
            min = b < a ? b : a;
        }
        Console.WriteLine("Result: {0} {1} {2}", max, middle, min);
    }
}