namespace IdentityApp.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Data;
    using Data.Contracts;
    using IdentityApp.Models;

    public class BaseController : Controller
    {
        public BaseController()
            : this(new IdentityAppData(new IdentityAppContext()))
        {
        }

        public BaseController(IdentityAppData data)
        {
            this.Data = data;
        }

        public User UserProfile { get; set; }

        public IIdentityAppData Data { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}