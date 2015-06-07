namespace MultimediaShop.Models
{
    using System;
    using System.Collections.Generic;

    public class Video : Item
    {
        private double movieLength;

        public Video(string id, string title, decimal price, double movieLength, List<string> genres)
            : base(id, title, price, genres)
        {
            this.MovieLength = movieLength;
        }

        public Video(string id, string title, decimal price, double movieLength, string genre)
            : this(id, title, price, movieLength, new List<string>(){genre})
        {
        }

        public double MovieLength
        {
            get { return this.movieLength; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("movieLength", "Movie length cannot be negative.");
                }

                this.movieLength = value;
            }
        }
    }
}