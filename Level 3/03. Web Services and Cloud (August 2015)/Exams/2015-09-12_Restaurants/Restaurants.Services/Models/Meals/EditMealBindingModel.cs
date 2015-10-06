using System.ComponentModel.DataAnnotations;

namespace Restaurants.Services.Models.Meals
{
    public class EditMealBindingModel
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int TypeId { get; set; }
    }
}