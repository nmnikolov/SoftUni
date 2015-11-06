namespace Twitter.Web.Controllers
{
    using System.Web.Routing;
    using Data;
    using Twitter.Models;
    using System;
    using System.Linq;
    using System.Web.Mvc;

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
                this.ViewBag.notifications = this.UserProfile.Notifications.Count(n => n.IsRead == false);
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}