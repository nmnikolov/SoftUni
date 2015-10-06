using Restaurants.Models;

namespace Restaurants.Services.Models.Orders
{
    using System;
    using Meals;
    using System.Linq.Expressions;

    public class OrderViewModel
    {
        public int Id { get; set; }

        public MealViewModel Meal { get; set; }
        
        public int Quantity { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public DateTime CreatedOn { get; set; }

        public static Expression<Func<Order, OrderViewModel>> Create
        {
            get
            {
                return o => new OrderViewModel
                {
                    Id = o.Id,
                    Meal = new MealViewModel
                    {
                        Id = o.Meal.Id,
                        Name = o.Meal.Name,
                        Price = o.Meal.Price,
                        Type = o.Meal.Type.Name
                    },
                    Quantity = o.Quantity,
                    OrderStatus = o.OrderStatus,
                    CreatedOn = o.CreatedOn
                };
            }
        }
    }
}