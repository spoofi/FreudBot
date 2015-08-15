using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Spoofi.FreudBot.Logic.Bot;

namespace Spoofi.FreudBot.Web
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DependenciesConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bot.Get();
        }
    }
}
