using DA_Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DA_Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute("redirect all other requests", "{*url}",
            //  new
            //  {
            //      controller = "UnderConstruction",
            //      action = "Index"
            //  }).DataTokens = new RouteValueDictionary(new { area = "Shop" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Display", action = "TrangChu", id = UrlParameter.Optional }
            );

            
        }
    }
}
