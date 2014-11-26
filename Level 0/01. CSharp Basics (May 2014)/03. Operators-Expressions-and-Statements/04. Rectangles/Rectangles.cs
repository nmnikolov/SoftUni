using System;

//Write an expression that calculates rectangle’s perimeter and area by given width and height. Examples:
// | width | height | perimeter | area |
// |     3 |      4	|        14	|   12 |
// |   2.5 |      3	|        11	|  7.5 |
// |     5 |      5	|        20	|   25 |

class Rectangles
{
    static void Main()
    {
        Console.Write("Input width: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Input height: ");
        double height = double.Parse(Console.ReadLine());
        double perimeter = 2 * width + 2 * height;
        double area = width * height;
        Console.WriteLine("Rectangle’s perimeter: {0}", perimeter);
        Console.WriteLine("Rectangle’s area: {0}", area);
    }
}