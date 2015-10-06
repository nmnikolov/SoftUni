namespace Restaurants.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Restaurants.Models;
    using Infrastructure;
    using Models.Meals;
    using Models.Orders;

    [Authorize]
    public class MealsController : BaseApiController
    {
        public MealsController()
            : this(new RestaurantsData(RestaurantsContext.Create()), new AspNetUserProvider())
        {
        }

        public MealsController(IRestaurantsData data, IUserProvider userProvider)
            : base(data, userProvider)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/restaurants/{id}/meals")]
        public IHttpActionResult GetRestaurantMeals(int id)
        {
            if (!this.RestaurantsData.Restaurants.All().Any(r => r.Id == id))
            {
                return this.NotFound();
            }

            var meals = this.RestaurantsData.Meals.All()
                .Where(m => m.RestaurantId == id)
                .OrderByDescending(m => m.Type.Name)
                .ThenBy(m => m.Name)
                .Select(MealViewModel.Create);

            return this.Ok(meals);
        }
        
        [HttpPost]
        [Route("api/meals")]
        public IHttpActionResult CreateMeal([FromBody] CreateMealBindingModel model)
        {
            var loggedUserId = this.UserProvider.GetUserId();
            var loggedUser = this.RestaurantsData.Users.Find(loggedUserId);
            if (loggedUser == null)
            {
                return this.Unauthorized();
            }

            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var restaurant = this.RestaurantsData.Restaurants.Find(model.RestaurantId);
            var mealType = this.RestaurantsData.MealTypes.Find(model.TypeId);
            if (restaurant == null || mealType == null)
            {
                return this.BadRequest();
            }

            var meal = new Meal
            {
                Name = model.Name,
                Price = model.Price,
                RestaurantId = restaurant.Id,
                Restaurant = restaurant,
                TypeId = mealType.Id,
                Type = mealType
            };

            this.RestaurantsData.Meals.Add(meal);
            this.RestaurantsData.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { controller = "meals", id = restaurant.Id }, MealViewModel.CreateView(meal));
        }

        [HttpPut]
        [Route("api/meals/{id}")]
        public IHttpActionResult EditMealById(int id, [FromBody] EditMealBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var mealType = this.RestaurantsData.MealTypes.Find(model.TypeId);
            if (mealType == null)
            {
                return this.BadRequest();
            }

            var meal = this.RestaurantsData.Meals.Find(id);
            if (meal == null)
            {
                return this.NotFound();
            }

            var loggedUserId = this.UserProvider.GetUserId();
            var loggedUser = this.RestaurantsData.Users.Find(loggedUserId);
            if (loggedUser == null || meal.Restaurant.OwnerId != loggedUserId)
            {
                return this.Unauthorized();
            }

            meal.Name = model.Name;
            meal.Price = model.Price;
            meal.Type = mealType;

            this.RestaurantsData.SaveChanges();

            return this.Ok(MealViewModel.CreateView(meal));
        }

        [HttpDelete]
        [Route("api/meals/{id}")]
        public IHttpActionResult DeleteMealById(int id)
        {
            var meal = this.RestaurantsData.Meals.Find(id);
            if (meal == null)
            {
                return this.NotFound();
            }

            var loggedUserId = this.UserProvider.GetUserId();
            var loggedUser = this.RestaurantsData.Users.Find(loggedUserId);
            if (loggedUser == null || meal.Restaurant.OwnerId != loggedUserId)
            {
                return this.Unauthorized();
            }

            this.RestaurantsData.Meals.Delete(meal);
            this.RestaurantsData.SaveChanges();

            return this.Ok(new
            {
                message = string.Format("Meal #{0} deleted.", meal.Id)
            });
        }
    }
}
