namespace MultimediaShop.Models
{
    using System.Collections.Generic;

    public class Game : Item
    {
        public Game(string id, string title, decimal price, List<string> genres, AgeRestriction ageRestriction = AgeRestriction.Minor)
            : base(id, title, price, genres)
        {
            this.AgeRestriction = ageRestriction;
        }

        public Game(string id, string title, decimal price, string genre, AgeRestriction ageRestriction = AgeRestriction.Minor)   
            : this(id, title, price, new List<string>(){genre}, ageRestriction)
        {
        }

        public AgeRestriction AgeRestriction { get; set; }
    }
}