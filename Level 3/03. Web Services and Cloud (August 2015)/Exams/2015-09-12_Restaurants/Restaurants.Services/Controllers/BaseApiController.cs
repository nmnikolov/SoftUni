namespace Restaurants.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Results;
    using Data;
    using Infrastructure;

    public class BaseApiController : ApiController
    {
        protected BaseApiController()
            : this(new RestaurantsData(RestaurantsContext.Create()), new AspNetUserProvider())
        {
        }

        protected BaseApiController(IRestaurantsData data, IUserProvider userProvider)
        {
            this.RestaurantsData = data;
            this.UserProvider = userProvider;
        }

        public IRestaurantsData RestaurantsData { get; set; }

        protected IUserProvider UserProvider { get; set; }

        protected ResponseMessageResult CreateResponseMessage(HttpStatusCode statusCode, string message)
        {
            return this.ResponseMessage(this.Request.CreateResponse(statusCode,
                new
                {
                    Message = message
                }));
        }
    }
}
