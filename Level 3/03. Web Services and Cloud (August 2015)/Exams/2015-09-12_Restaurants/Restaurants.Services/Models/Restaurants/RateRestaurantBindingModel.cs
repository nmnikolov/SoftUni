using System.ComponentModel.DataAnnotations;

namespace Restaurants.Services.Models.Restaurants
{
    public class RateRestaurantBindingModel
    {
        [Range(0, 10)]
        public int Stars { get; set; } 
    }
}