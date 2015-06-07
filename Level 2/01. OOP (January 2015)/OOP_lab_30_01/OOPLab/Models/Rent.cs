namespace MultimediaShop.Models
{
    using System;
    using Interfaces;

    public class Rent : IRent
    {
        private Item item;

        public Rent(Item item, DateTime rentDate, DateTime deadline)
        {
            this.Item = item;
            this.RentDate = rentDate;
            this.Deadline = deadline;
        }

        public Rent(Item item, DateTime rentDate)
            : this(item, rentDate, rentDate.AddDays(30))
        {
        }

        public Rent(Item item)
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

        public RentState RentState
        {
            get
            {
                if (this.ReturnDate > DateTime.MinValue)
                {
                    return RentState.Returend;
                }

                return this.Deadline >= DateTime.Now ? RentState.Pending : RentState.Overdue;

            }
        }

        public DateTime RentDate { get; set; }

        public DateTime Deadline { get; set; }

        public DateTime ReturnDate { get; set; }

        public decimal RentFine {
            get
            {
                decimal rentFine = (this.ReturnDate - this.Deadline).Days * this.Item.Price * 0.01M;
                return rentFine < 0 ? 0 : rentFine;
            }
        }

        public void ReturnItem()
        {
            this.ReturnDate = DateTime.Now;
        }
    }
}