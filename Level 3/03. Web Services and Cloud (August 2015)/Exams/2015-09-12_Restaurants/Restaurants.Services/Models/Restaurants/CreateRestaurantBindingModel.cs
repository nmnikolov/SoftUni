using System.ComponentModel.DataAnnotations;

namespace Restaurants.Services.Models.Restaurants
{
    public class CreateRestaurantBindingModel
    {
        [Required]
        public string Name { get; set; }

        public int TownId { get; set; }
    }
}