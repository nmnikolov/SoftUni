using System;
using System.Linq.Expressions;
using Restaurants.Models;

namespace Restaurants.Services.Models.Meals
{
    public class MealViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }

        public static Expression<Func<Meal, MealViewModel>> Create
        {
            get
            {
                return m => new MealViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Price = m.Price,
                    Type = m.Type.Name
                };
            }
        }

        public static MealViewModel CreateView(Meal meal)
        {
            return new MealViewModel
            {
                Id = meal.Id,
                Name = meal.Name,
                Price = meal.Price,
                Type = meal.Type.Name
            };
        }
    }
}