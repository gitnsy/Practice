using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Practice
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "View",
                url: "{controller}/{action}/{query}",
                defaults: new { controller = "GuildView", action = "Result" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "GuildView", action = "Index" }
            );
            routes.MapRoute(
                name: "Root",
                url: "",
                defaults: new { controller = "GuildView", action = "Index"}
            );
        }
    }
}