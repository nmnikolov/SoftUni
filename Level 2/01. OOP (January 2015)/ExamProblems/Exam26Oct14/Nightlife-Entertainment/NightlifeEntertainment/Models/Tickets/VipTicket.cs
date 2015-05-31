namespace NightlifeEntertainment.Models.Tickets
{
    public class VipTicket : Ticket
    {
        private const decimal TicketDiscount = 1.5M;

        public VipTicket(IPerformance performance) 
            : base(performance, TicketType.VIP)
        {
            this.Price = performance.BasePrice * TicketDiscount;
        }
    }
}