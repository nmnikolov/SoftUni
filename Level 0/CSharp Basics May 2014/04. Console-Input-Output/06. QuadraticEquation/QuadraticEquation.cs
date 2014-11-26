using System;

//Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots). Examples:
// |    a | b |  c | roots         |
// |    2 | 5 | -3 | x1=-3; x2=0.5 |
// |   -1 | 3 |  0 | x1=3; x2=0    |
// | -0.5 | 4 | -8 | x1=x2=4       |
// |    5 | 2 |  8 | no real roots |

class QuadraticEquation
{
    static void Main()
    {
        Console.Write("Input а: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Input b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Input c: ");
        double c = double.Parse(Console.ReadLine());
        double x1;
        double x2;
        double discriminant = b * b - 4.0 * a * c;

        if (discriminant == 0 && a != 0)
        {
            x1 = (-b - Math.Sqrt(discriminant)) / (2.0 * a);         
            Console.WriteLine("x1=x2={0}", x1);
        }
        else if (discriminant > 0 && a != 0)
        {
            x1 = (-b - Math.Sqrt(discriminant)) / (2.0 * a);
            x2 = (-b + Math.Sqrt(discriminant)) / (2.0 * a);
            Console.WriteLine("x1={0}; x2={1}", x1, x2);
        }
        else if (discriminant < 0 && a != 0)
        {
            Console.WriteLine("no real roots");
        }
        else
        {
            Console.WriteLine("a can't be 0");
        }
    }
}