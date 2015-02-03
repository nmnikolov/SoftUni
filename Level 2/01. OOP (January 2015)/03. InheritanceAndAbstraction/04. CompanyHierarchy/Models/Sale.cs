namespace Company.Models
{
    using System;
    using Interfaces;

    public class Sale : ISale
    {
        private string productName;

        private DateTime saleDate ;

        private decimal price;

        public Sale(string productName, DateTime saleDate, decimal price)
        {
            this.ProductName = productName;
            this.SaleDate = saleDate;
            this.Price = price;
        }

        public DateTime SaleDate { get; set; }

        public string ProductName {
            get { return this.productName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Product name cannot be empty.");
                }

                this.productName = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("price", "Product proce cannot be negative.");
                }

                this.price = value;
            }
        }
    }
}