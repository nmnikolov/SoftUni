namespace Restaurants.Services.Models.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class MealOrderBindingModel
    {
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; } 
    }
}