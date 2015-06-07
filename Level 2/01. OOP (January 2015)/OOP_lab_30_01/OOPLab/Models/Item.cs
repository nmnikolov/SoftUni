namespace MultimediaShop.Models
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public abstract class Item : IItem
    {
        private static readonly List<string> ids = new List<string>();

        private string id;

        private string title;

        private decimal price;

        private List<string> genres;

        protected Item(string id, string title, List<string> genres)
        {
            this.Id = id;
            this.Title = title;
            this.Genres = genres;
        }

        protected Item(string id, string title, decimal price, List<string> genres)
            : this(id, title, genres)
        {
            this.Price = price;
        }

        public string Id
        {
            get { return this.id; }
            set
            {
                if (ids.Contains(value))
                {
                    throw new DuplicateNameException("Item with this ID already exists.");
                }

                if (String.IsNullOrEmpty(value) || value.Length < 4)
                {
                    throw new ArgumentOutOfRangeException("id", "ID should be at least 4 symbols long.");
                }

                ids.Add(value);
                this.id = value;
            }
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title cannot be empty.");
                }

                this.title = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("price", "Price cannot be negative.");
                }

                this.price = value;
            }
        }

        public List<string> Genres { get; set; }
    }
}