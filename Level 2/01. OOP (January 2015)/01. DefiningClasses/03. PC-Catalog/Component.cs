namespace _03.PCCatalog
{
    using System;

    public class Component
    {
        private string type;

        private string details;

        private decimal price;

        public Component(string type, decimal price, string details = null)
        {
            this.Type = type;
            this.Details = details;
            this.Price = price;
        }

        public string Type
        {
            get
            {
                return this.type;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Component type cannot be empty.");
                }

                this.type = value;
            }
        }

        public string Details
        {
            get
            {
                return this.details;
            }

            private set
            {
                if (value != null && value.Trim() == string.Empty)
                {
                    throw new ArgumentException("Component details cannot be empty.");
                }

                this.details = value;
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
                if (value < 0)
                {
                    throw new ArgumentException("Component price cannot be negative.");
                }

                this.price = value;
            }
        }
        
        public override string ToString()
        {
            string result = string.Format("\n{0}:\n", this.type);

            if (this.details != null)
            {
                result += string.Format("Details: {0}\n", this.details);
            }

            result += string.Format("Price: {0:F2} BGN\n", this.price);

            return result;
        }
    }
}
