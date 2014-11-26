using System;

//Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2). Examples:
// |    x |	   y | inside K & outside of R |	 
// |    1 |	   2 | yes	                   |
// |  2.5 |	   2 | no	                   |
// |    0 |	   1 | no	                   |
// |  2.5 |	   1 | no	                   |
// |    2 |	   0 | no	                   |
// |    4 |	   0 | no	                   |
// |  2.5 |  1.5 | no	                   |
// |    2 |  1.5 | yes	                   |
// |    1 |  2.5 | yes	                   |
// | -100 |	-100 | no	                   |

class CircleRectanglePoint
{
    static void Main()
    {
        Console.Write("Input x: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Input y: ");
        double y = double.Parse(Console.ReadLine());
        bool outsideRectangle = x < -1 || x > 5 || y < -1 || y > 1;
        bool insideCircle = ((x - 1) * (x - 1) + (y - 1) * (y - 1)) <= 1.5 * 1.5;
        Console.WriteLine(outsideRectangle && insideCircle ? "Inside K & outside of R: yes" : "inside K & outside of R: no");
    }
}