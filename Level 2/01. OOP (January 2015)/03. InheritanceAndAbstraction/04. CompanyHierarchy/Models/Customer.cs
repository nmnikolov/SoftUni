namespace Company.Models
{
    using System;
    using System.Text;
    using Interfaces;

    public class Customer : Person, ICustomer
    {
        private decimal purchasesAmmount;

        public Customer(string id, string firstName, string lastName, decimal purchasesAmmount = 0m) 
            : base(id, firstName, lastName)
        {
            this.PurchasesAmmount = purchasesAmmount;
        }

        public decimal PurchasesAmmount
        {
            get { return this.purchasesAmmount; }
            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("purchasesAmmount", "Purchases ammount cannot be empty.");
                }

                this.purchasesAmmount = value;
            }
        }

        public void AddPurchasePrice(decimal purchasePrice)
        {
            this.PurchasesAmmount += purchasePrice;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat("Purchases ammount: {0}\n", this.PurchasesAmmount);
            
            return result.ToString();
        }
    }
}