namespace Restaurants.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Infrastructure;
    using Models.Orders;
    using Restaurants.Models;

    [Authorize]
    public class OrdersController : BaseApiController
    {
        public OrdersController()
            : this(new RestaurantsData(RestaurantsContext.Create()), new AspNetUserProvider())
        {
        }

        public OrdersController(IRestaurantsData data, IUserProvider userProvider)
            : base(data, userProvider)
        {
        }

        [HttpPost]
        [Route("api/meals/{id}/order")]
        public IHttpActionResult CreateMealOrder(int id, [FromBody] MealOrderBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var meal = this.RestaurantsData.Meals.Find(id);
            if (meal == null)
            {
                return this.NotFound();
            }

            var loggedUserId = this.UserProvider.GetUserId();
            var loggedUser = this.RestaurantsData.Users.Find(loggedUserId);
            if (loggedUser == null)
            {
                return this.Unauthorized();
            }

            var order = new Order
            {
                Quantity = model.Quantity,
                OrderStatus = OrderStatus.Pending,
                CreatedOn = DateTime.Now,
                MealId = meal.Id,
                UserId = loggedUserId
            };

            this.RestaurantsData.Orders.Add(order);
            this.RestaurantsData.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        [Route("api/orders")]
        public IHttpActionResult GetPendingOrders([FromUri] PendingOrdersBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var loggedUserId = this.UserProvider.GetUserId();
            var loggedUser = this.RestaurantsData.Users.Find(loggedUserId);
            if (loggedUser == null)
            {
                return this.Unauthorized();
            }

            IQueryable<Order> orders = this.RestaurantsData.Orders.All()
                .Where(o => o.UserId == loggedUserId && o.OrderStatus == OrderStatus.Pending)
                .OrderByDescending(o => o.CreatedOn);

            if (model.MealId != null)
            {
                orders = orders.Where(o => o.MealId == model.MealId);
            }

            var result = orders
                .Skip(model.Limit * model.StartPage)
                .Take(model.Limit)
                .Select(OrderViewModel.Create);
                
            return this.Ok(result);
        }
    }
}
