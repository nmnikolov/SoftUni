using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Restaurants.Data;
using Restaurants.Models;
using Restaurants.Services.Infrastructure;
using Restaurants.Services.Models.Restaurants;

namespace Restaurants.Services.Controllers
{
    [Authorize]
    public class RestaurantsController : BaseApiController
    {
        public RestaurantsController()
            : this(new RestaurantsData(RestaurantsContext.Create()), new AspNetUserProvider())
        {
        }

        public RestaurantsController(IRestaurantsData data, IUserProvider userProvider)
            : base(data, userProvider)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/restaurants")]
        public IHttpActionResult GetRestaurantsByTown([FromUri] RestaurantsByTownBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var response = this.RestaurantsData.Restaurants.All()
                .Where(r => r.TownId == model.TownId)
                .OrderByDescending(r => r.Ratings.Average(rr => rr.Stars))
                .ThenBy(r => r.Name)
                .Select(RestaurantsByTownViewModel.Create);

            return this.Ok(response);
        }

        [HttpPost]
        [Route("api/restaurants")]
        public IHttpActionResult CreateRestaurant([FromBody] CreateRestaurantBindingModel model)
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

            var restaurant = new Restaurant
            {
                Name = model.Name,
                TownId = model.TownId,
                OwnerId = loggedUserId,
                Owner = loggedUser
            };

            this.RestaurantsData.Restaurants.Add(restaurant);
            this.RestaurantsData.SaveChanges();

            var dbRestaurant = this.RestaurantsData.Restaurants.All()
                .Where(r => r.Id == restaurant.Id)
                .Select(RestaurantsByTownViewModel.Create)
                .FirstOrDefault();
            
            return this.CreatedAtRoute("DefaultApi", new { controller = "news", id = restaurant.Id }, dbRestaurant);
        }

        [HttpPost]
        [Route("api/restaurants/{id}/rate")]
        public IHttpActionResult RateRestaurant(int id, [FromBody] RateRestaurantBindingModel model)
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

            var restaurant = this.RestaurantsData.Restaurants.Find(id);

            if (restaurant == null)
            {
                return this.NotFound();
            }

            if (restaurant.OwnerId == loggedUserId)
            {
                return this.BadRequest();
            }

            var restaurantRating = restaurant.Ratings.FirstOrDefault(r => r.UserId == loggedUserId);

            if (restaurantRating != null)
            {
                restaurantRating.Stars = model.Stars;
            }
            else
            {
                restaurant.Ratings.Add(new Rating
                {
                    Stars = model.Stars,
                    UserId = loggedUserId,
                    User = loggedUser
                });
            }

            this.RestaurantsData.SaveChanges();

            return this.Ok();
        }


    }
}