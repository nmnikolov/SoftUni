namespace MusicShopManager.Models
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class Article : IArticle
    {
        protected const string DefaultRequiredMessage = "The {0} is required";
        protected const string DefaultPositiveMessage = "The {0} must be positive";
        private string make;
        private string model;
        private decimal price;

        protected Article(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public string Make 
        {
            get
            {
                return this.make;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(DefaultRequiredMessage, "make"));
                }

                this.make = value;
            }
        }

        public string Model 
        {
            get
            {
                return this.model;
            }
            
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(DefaultRequiredMessage, "model"));
                }

                this.model = value;
            }
        }

        public decimal Price 
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(DefaultPositiveMessage, "price"));
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("= {0} {1} =", this.Make, this.Model));
            output.AppendLine(string.Format("Price: ${0:F2}", this.Price));

            return output.ToString();
        }
    }
}