using System.Web.Http;
using LightInject;
using Spoofi.FreudBot.Logic;
using Spoofi.FreudBot.Utils;

namespace Spoofi.FreudBot.Web
{
    public static class DependenciesConfig
    {
        public static void Configure()
        {
            var container = DependenciesResolver.Container;
            LogicDependenciesConfig.Register(container);

            container.RegisterApiControllers();
            container.EnablePerWebRequestScope();
            container.EnableWebApi(GlobalConfiguration.Configuration);
        }
    }
}
