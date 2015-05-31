namespace NightlifeEntertainment.Models.Tickets
{
    public class StudentTicket : Ticket
    {
        private const decimal TicketDiscount = 0.8M;

        public StudentTicket(IPerformance performance) 
            : base(performance, TicketType.Student)
        {
            this.Price = performance.BasePrice * TicketDiscount;
        }
    }
}