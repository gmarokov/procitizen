﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Reporter.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Enable Attribute Routing
            routes.MapMvcAttributeRoutes();
           // routes.MapRoute(
           //    name: "Default2",
           //    url: "{controller}/{action}/{id}",
           //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Reporter.Web.Controllers" }
            );

           
        }
    }
}
