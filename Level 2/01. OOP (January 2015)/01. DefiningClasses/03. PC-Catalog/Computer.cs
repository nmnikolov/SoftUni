namespace _03.PCCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Computer
    {
        private string name;

        private List<Component> components = new List<Component>();

        private decimal totalPrice;

        public Computer(string name, params Component[] list)
        {
            this.totalPrice = 0m;
            this.Name = name;
            this.AddComponents(list);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Computer name cannot be empty.");
                }

                this.name = value;
            }
        }

        public decimal TotalPrice 
        {
            get
            {
                return this.totalPrice;
            }
        }
        
        public void AddComponents(params Component[] list)
        {
            foreach (Component component in list.Where(component => component != null))
            {
                this.components.Add(component);
                this.totalPrice += component.Price;
            }
        }

        public override string ToString()
        {
            string result = string.Format("MODEL: {0}\n", this.name);
            result = this.components.Aggregate(result, (current, t) => current + t);
            result += string.Format("\nTOTAL PRICE: {0:F2} BGN\n", this.TotalPrice);
            return result;
        }
    }
}
