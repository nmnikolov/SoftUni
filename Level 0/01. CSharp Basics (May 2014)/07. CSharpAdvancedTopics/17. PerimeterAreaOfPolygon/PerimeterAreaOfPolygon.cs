using System;

//Write a program that calculates the perimeter and the area of given polygon (not necessarily convex) consisting of n floating-point coordinates 
//in the 2D plane. Print the result rounded to two decimal digits after the decimal point. Use the input and output format from the examples. 
//To hold the points, define a class Point(x, y). To hold the polygon use a Polygon class which holds a list of points. 
//Find in Internet how to calculate the polygon perimeter and how to calculate the area of a polygon. Examples:
// | Input | Output            |
// |-------|-------------------|
// |  3    | perimeter = 3.41  |
// |  0  0 | area = 0.50       |
// |  0  1 |                   |
// |  1  1 |                   |
// |-------|-------------------|
// |  7    | perimeter = 22.64 |
// | -2  1 | area = 9.50       |
// |  1  3 |                   |
// |  5  1 |                   |
// |  1  2 |                   |
// |  1  1 |                   |
// |  3 -2 |                   |
// | -2  1 |                   |

class Point
{
    public double X { get; set; }
    public double Y { get; set; }
}

class Polygon
{
    public static double Area(Point[] p, int n)
    {
        double area = 0;

        for (int i = 0; i < n; i++)
        {
            if (i == n - 1)
            {
                area += p[i].X * p[0].Y - p[0].X * p[i].Y;
                continue;
            }

            area += p[i].X * p[i + 1].Y - p[i + 1].X * p[i].Y;
        }
        return Math.Abs(area / 2.0);
    }

    public static double Perimeter(Point[] p, int n)
    {
        double perimeter = 0;
        double x = 0;
        double y = 0;

        for (int i = 0; i < n; i++)
        {
            if (i == n -1)
            {
                x = p[i].X - p[0].X;
                y = p[i].Y - p[0].Y;
                perimeter += Math.Sqrt(x * x + y * y);
		        continue;
            }

            x = p[i].X - p[i + 1].X;
            y = p[i].Y - p[i + 1].Y;
            perimeter += Math.Sqrt(x * x + y * y);
        }
        return perimeter;
    }
}

class PerimeterAreaOfPolygon
{
    public static void Main()
    {
        Console.Write("Enter number of points: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter point coordinates on a line, separated by a space -> x y");
        Point[] point = new Point[n];
        
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter point[{0}]: ", i + 1);
            string[] pointCoordinates = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            point[i] = new Point() { X = double.Parse(pointCoordinates[0]), Y = double.Parse(pointCoordinates[1]) };
        }

        double calcPerimeter = Polygon.Perimeter(point, n);
        double calcArea = Polygon.Area(point, n);
        Console.WriteLine("\nperimeter = {0:F2}", calcPerimeter);
        Console.WriteLine("area = {0:F2}", calcArea);       
    }  
}