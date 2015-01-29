namespace DistanceCalculator
{
    using System;
    using Point;

    public class CalculatorTest
    {
        public static void Main()
        {
            Point3D point1 = new Point3D(-7, -4, 3);
            Point3D point2 = new Point3D(17, 6, 2.5);
            Console.WriteLine(DistanceCalculator.CalculateDistance(point1, point2));
        }
    }
}