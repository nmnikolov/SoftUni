using System;

//Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point. Examples:
// |   r | perimeter |  area |
// |   2 |     12.57 | 12.57 |
// | 3.5 |     21.99 | 38.48 |

class CirclePerimeterАndArea
{
    static void Main()
    {
        Console.Write("Input radius: ");
        double radius = double.Parse(Console.ReadLine());
        double perimeter = 2 * Math.PI * radius;
        double area = Math.PI * Math.Pow(radius, 2);
        Console.WriteLine("Perimeter of the circle: {0:F2}", perimeter);
        Console.WriteLine("Area of the circle: {0:F2}", area);
    }
}