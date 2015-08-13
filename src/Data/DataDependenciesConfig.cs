using LightInject;
using Spoofi.FreudBot.Data.Services;

namespace Spoofi.FreudBot.Data
{
    public static class DataDependenciesConfig
    {
        public static void Register(ServiceContainer container)
        {
            container.RegisterAssembly(typeof(IDatabaseService).Assembly);
        }
    }
}