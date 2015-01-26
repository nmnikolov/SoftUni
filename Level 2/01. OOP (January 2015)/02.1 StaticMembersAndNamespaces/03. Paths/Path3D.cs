using System;
using System.Collections.Generic;
using System.Text;
using Point;

namespace Paths
{
    public class Path3D
    {
        private readonly List<Point3D> path = new List<Point3D>();

        public List<Point3D> Path {
            get { return this.path; }
        }

        public Path3D(params Point3D[] list)
        {
            AddPoints(list);
        }

        public void AddPoints(params Point3D[] list)
        {
            foreach (var point in list)
            {
                this.path.Add(point);
            }
        }

        public override string ToString()
        {

            StringBuilder result = new StringBuilder("Path:\n");

            for (int i = 0; i < this.Path.Count; i++)
            {
                result.AppendFormat("point{0}: x={1} y={2} z={3}\n", (i + 1),
                    this.Path[i].X, this.Path[i].Y, this.Path[i].Z);
            }

            return result.ToString();
        }
    }
}
