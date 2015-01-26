using System;
using Point;

namespace DistanceCalculator
{
    public static class DistanceCalculator
    {
        public static double CalculateDistance(Point3D point1, Point3D point2)
        {
            double distanceA = Math.Pow(point2.X - point1.X, 2);
            double distanceB = Math.Pow(point2.Y - point1.Y, 2);
            double distanceC = Math.Pow(point2.Z - point1.Z, 2);
            double distance = Math.Sqrt( distanceA + distanceB + distanceC);

            return distance;
        }
    }
}
