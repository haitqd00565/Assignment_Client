using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Assignment_Client
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Address Detail",
                url: "chi-tiet-dia-diem-{id}",
                defaults: new { controller = "Home", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Assignment_Client.Controllers" }
            );
            routes.MapRoute(
                name: "Address",
                url: "dia-diem",
                defaults: new { controller = "Home", action = "Service", id = UrlParameter.Optional },
                namespaces: new[] { "Assignment_Client.Controllers" }
            );


            routes.MapRoute(
                name: "Default1",
                url: "{controller}/{action}/{id}",
                defaults: new {controller ="Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Assignment_Client.Controllers" }
            );

            routes.MapRoute(
                name: "Admin1_Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Assignment_Client.Areas.Controllers" }
            );
        }
    }
}
