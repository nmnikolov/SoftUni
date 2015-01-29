namespace Paths
{
    using System;
    using System.IO;
    using Point;

    class PathTest
    {
        public static void Main()
        {
            try
            {
                Point3D point1 = new Point3D(1, 10, 1);
                Point3D point2 = new Point3D(-3, 33333, 3);
                Path3D path = new Path3D(point1, point2);

                //Storage.SavePathToFile("text.txt", path.ToString());
                Console.WriteLine("Load from file:\n" + Storage.LoadPathFromFile("text.txt"));
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }                    
        }
    }
}