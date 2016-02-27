using System;
using System.Collections.Generic;

namespace ToTheStars
{
    public class ToTheStars
    {
        public static void Main()
        {
            ICollection<Star> stars = ReadStars();
            Position position = ReadCoordinates();
            int moves = int.Parse(Console.ReadLine());

            for (int i = 0; i <= moves; i++)
            {
                string location = GetLocation(position, stars);
                Console.WriteLine(location);
                position.Y++;
            }
        }

        private static string GetLocation(Position position, ICollection<Star> stars)
        {
            foreach (Star star in stars)
            {
                if (position.X >= star.X - 1 && position.X <= star.X + 1 && position.Y >= star.Y - 1 && position.Y <= star.Y + 1)
                {
                    return star.Name;
                }
            }

            return "space";
        }

        private static Position ReadCoordinates()
        {
            string[] positionRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Position position = new Position { X = double.Parse(positionRow[0]), Y = double.Parse(positionRow[1]) };

            return position;
        }

        private static ICollection<Star> ReadStars()
        {
            List<Star> stars = new List<Star>();

            for (int i = 0; i < 3; i++)
            {
                string[] starRow = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                stars.Add(new Star
                {
                    Name = starRow[0].ToLower(),
                    X = double.Parse(starRow[1]),
                    Y = double.Parse(starRow[2]),
                });
            }

            return stars;
        }
    }

    public class Star
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class Position
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}