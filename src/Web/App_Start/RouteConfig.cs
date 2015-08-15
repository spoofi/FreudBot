using System.Web.Mvc;
using System.Web.Routing;

namespace Spoofi.FreudBot.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Ping", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
