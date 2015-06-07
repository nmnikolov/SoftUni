namespace MultimediaShop.Models
{
    using System;
    using Interfaces;

    public class Sale : ISale
    {
        private Item item;

        public Sale(Item item, DateTime dateOfPurchase)
        {
            this.Item = item;
            this.SaleDate = dateOfPurchase;
        }

        public Sale(Item item)
            : this(item, DateTime.Now)
        {
        }
        
        public Item Item
        {
            get { return this.item; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("item", "Item cannot be null.");
                }

                this.item = value;
            } 
        }

        public DateTime SaleDate { get; set; }
    }
}