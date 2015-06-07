namespace Customer
{
    public class Payment
    {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }

            set
            {
                Validation.IsValidName(value, "ProductName");
                this.productName = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                Validation.IsValidPrice(value);
                this.price = value;
            }
        }
    }
}