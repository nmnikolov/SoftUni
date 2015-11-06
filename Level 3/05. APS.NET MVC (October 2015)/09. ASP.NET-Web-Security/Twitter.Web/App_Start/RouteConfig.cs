using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Twitter.Web
{
    using System.Web.Http;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index"}
            );

            routes.MapRoute(
                name: "Notifications",
                url: "notifications",
                defaults: new { controller = "Notifications", action = "Index" }
            );

            routes.MapRoute(
                name: "Manage",
                url: "manage",
                defaults: new { controller = "Manage", action = "Index" }
            );


            routes.MapRoute(
                name: "UserPage",
                url: "{username}",
                defaults: new { controller = "Users", action = "Index"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
