using System;
using System.Linq;
using System.Linq.Expressions;
using Restaurants.Models;
using Restaurants.Services.Models.Towns;

namespace Restaurants.Services.Models.Restaurants
{
    public class RestaurantsByTownViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double? Rating { get; set; }

        public TownViewModel Town { get; set; }

        public static Expression<Func<Restaurant, RestaurantsByTownViewModel>> Create
        {
            get
            {
                return r => new RestaurantsByTownViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Rating = r.Ratings.Average(rr => rr.Stars),
                    Town = new TownViewModel
                    {
                        Id = r.Town.Id,
                        Name = r.Town.Name
                    }
                };
            }
        }
    }
}