using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PCCatalog
{
    class Computer
    {
        private string name;

        private List<Component> components = new List<Component>();

        private decimal totalPrice; 

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Computer name cannot be empty.");
                }

                this.name = value;
            }
        }

        public decimal TotalPrice {
            get { return this.totalPrice; }
        }

        public Computer(string name, params Component[] list)
        {
            this.totalPrice = 0m;
            this.Name = name;
            AddComponents(list);   
        }

        public void AddComponents(params Component[] list)
        {
            foreach (Component component in list.Where(component => component != null))
            {
                components.Add(component);
                this.totalPrice += component.Price;
            }
        }

        public override string ToString()
        {
            string result = String.Format("MODEL: {0}\n", this.name);
            result = components.Aggregate(result, (current, t) => current + t);
            result += String.Format("\nTOTAL PRICE: {0:F2} BGN\n", this.TotalPrice);
            return result;
        }
    }
}
