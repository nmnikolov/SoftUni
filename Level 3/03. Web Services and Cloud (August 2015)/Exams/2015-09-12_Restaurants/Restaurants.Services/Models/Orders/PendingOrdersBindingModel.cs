namespace Restaurants.Services.Models.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class PendingOrdersBindingModel
    {
        [Range(0, int.MaxValue)]
        public int StartPage { get; set; }

        [Range(2, 10)]
        public int Limit { get; set; }
        
        public int? MealId { get; set; }
    }
}