namespace Point
{
    using System;

    class Point3DMain
    {
        public static void Main()
        {
            Point3D point1 = new Point3D(0.0, -3.0, 10.15);

            Console.WriteLine(point1);
            Console.WriteLine(Point3D.StartingPoint);
        }
    }
}