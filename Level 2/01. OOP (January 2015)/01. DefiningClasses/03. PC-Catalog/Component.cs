using System;

namespace _03.PCCatalog
{
    class Component
    {
        private string type;

        private string details;

        private decimal price;

        public string Type
        {
            get { return this.type; }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Error");
                }
                this.type = value;
            }
        }


        public string Details
        {
            get { return this.details; }
            private set
            {
                if (value != null && value.Trim() == "")
                {
                    throw new ArgumentException("Error");
                }

                this.details = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Error");
                }

                this.price = value;
            }
        }

        public Component(string type, decimal price, string details = null)
        {
            this.Type = type;
            this.Details = details;
            this.Price = price;
        }

        public override string ToString()
        {
            string result = String.Format("\n{0}:\n", this.type);

            if (this.details != null)
            {
                result += String.Format("Details: {0}\n", this.details);
            }

            result += String.Format("Price: {0:C2} \n", this.price);

            return result;
        }
    }
}
