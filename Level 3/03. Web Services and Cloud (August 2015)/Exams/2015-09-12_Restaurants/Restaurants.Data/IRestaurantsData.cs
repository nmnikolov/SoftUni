namespace Restaurants.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Repositories;
    using Restauranteur.Models;

    public interface IRestaurantsData
    {
        IRepository<Rating> Ratings { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<IdentityRole> UserRoles { get; }

        IRepository<Town> Towns { get; }

        IRepository<Restaurant> Restaurants { get; }

        IRepository<Meal> Meals { get; }

        IRepository<MealType> MealTypes { get; }

        IRepository<Order> Orders { get; }

        int SaveChanges();
    }
}