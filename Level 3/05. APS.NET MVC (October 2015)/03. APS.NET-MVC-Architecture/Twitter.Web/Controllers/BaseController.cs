using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Twitter.Web.Controllers
{
    using System.Web.Routing;
    using Data;
    using Twitter.Models;

    public class BaseController : Controller
    {
        public BaseController()
            : this(new TwitterData(new TwitterContext()))
        {
        }

        public BaseController(ITwitterData data)
        {
            this.Data = data;
        }

        public ApplicationUser UserProfile { get; set; }

        public ITwitterData Data { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
                requestContext.HttpContext.Application["Fullname"] = this.UserProfile.Fullname;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}