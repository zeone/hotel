using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hotel
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "About",
                url: "About",
                defaults: new { controller = "Home", action = "About" }
            );

            routes.MapRoute(
                name: "Gallery",
                url: "Gallery",
                defaults: new { controller = "Home", action = "Gallery" }
            );

            routes.MapRoute(
                name: "Contact",
                url: "Contact",
                defaults: new { controller = "Home", action = "Contact" }
            );

            routes.MapRoute(
                name: "Healing",
                url: "Healing",
                defaults: new { controller = "Home", action = "Healing" }
            );

            routes.MapRoute(
                name: "Prices",
                url: "Prices",
                defaults: new { controller = "Home", action = "Prices" }
            );

            routes.MapRoute(
                name: "Reservation",
                url: "Reservation",
                defaults: new { controller = "Home", action = "Reservation" }
            );

            routes.MapRoute(
                name: "Rooms",
                url: "Rooms",
                defaults: new { controller = "Home", action = "Rooms" }
            );

            routes.MapRoute(
                name: "GetAppPrice",
                url: "GetAppPrice",
                defaults: new { controller = "Home", action = "GetAppPrice" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
