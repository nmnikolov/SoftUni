using System;

//Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it. Use a sequence of if operators. Examples:
// |  a |    b |    c | result |
// |  5 |    2 |    2 |      + |
// | -2 |   -2 |    1 |      + |
// | -2 |    4 |    3 |      - |
// |  0 | -2.5 |    4 |      0 |
// | -1 | -0.5 | -5.1 |      - |

class MultiplicationSign
{
    static void Main()
    {
        Console.Write("Input a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Input b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Input c: ");           
        double c = double.Parse(Console.ReadLine());

        if (a == 0 || b == 0 || c == 0)
        {
            Console.WriteLine("0");
        }
        else if (a < 0 && b < 0 && c < 0)
        {
            Console.WriteLine("-");
        }
        else if (a < 0 && b > 0 && c > 0)
        {
            Console.WriteLine("-");
        }
        else if (a > 0 && b < 0 && c > 0)
        {
            Console.WriteLine("-");
        }
        else if (a > 0 && b > 0 && c < 0)
        {
            Console.WriteLine("-");
        }
        else
        {
            Console.WriteLine("+");
        }
    }
}