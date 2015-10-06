namespace Restaurants.Services.Models.Meals
{
    using System.ComponentModel.DataAnnotations;

    public class CreateMealBindingModel
    {
        [Required]
        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public int TypeId { get; set; }

        public int RestaurantId { get; set; }
    }
}