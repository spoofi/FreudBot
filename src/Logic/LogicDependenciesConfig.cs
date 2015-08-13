using LightInject;
using Spoofi.FreudBot.Data;
using Spoofi.FreudBot.Logic.Bot;

namespace Spoofi.FreudBot.Logic
{
    public static class LogicDependenciesConfig
    {
        public static void Register(ServiceContainer container)
        {
            container.RegisterAssembly(typeof(IBotManager).Assembly);
            DataDependenciesConfig.Register(container);
        }
    }
}