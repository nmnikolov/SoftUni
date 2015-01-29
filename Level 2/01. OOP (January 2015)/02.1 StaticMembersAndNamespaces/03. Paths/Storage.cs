namespace Paths
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using Point;

    public static class Storage
    {
        public static void SavePathToFile(string filePath, string path)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(path);
            }
        }

        public static Path3D LoadPathFromFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                Path3D path = new Path3D();
                string line = reader.ReadLine();
                const string pointPattern = @"[xyz=:\-\s](\d+(?:(?:\.|,)\d+)*)";

                while (line != null)
                {
                    MatchCollection match = Regex.Matches(line, pointPattern);

                    if (match.Count == 3)
                    {
                        double x = Double.Parse(match[0].Groups[1].Value);
                        double y = Double.Parse(match[1].Groups[1].Value);
                        double z = Double.Parse(match[2].Groups[1].Value);

                        Point3D point = new Point3D(x, y, z);
                        path.AddPoints(point);
                    }

                    line = reader.ReadLine();
                }

                return path;
            }
        }
    }
}