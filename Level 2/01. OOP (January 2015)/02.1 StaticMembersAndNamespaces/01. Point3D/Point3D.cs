using System;

namespace Point
{
    public class Point3D
    {
        private static readonly Point3D startingPoint= new Point3D(0, 0, 0);

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }


        public static Point3D StartingPoint
        {
            get { return startingPoint; }
        }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            String result = String.Format("Point Coordinates:\nX: {0}\nY: {1}\nZ: {2}\n", 
                this.X, this.Y, this.Z);
            return result;
        }
    }
}