using LightInject;
using Spoofi.FreudBot.Data.Mongo;
using Spoofi.FreudBot.Data.Services;

namespace Spoofi.FreudBot.Data
{
    public static class DataDependenciesConfig
    {
        public static void Register(ServiceContainer container)
        {
            container.Register<IRepositoryFactory, RepositoryFactory>();
            container.Register<IDatabaseService, DatabaseService>();
        }
    }
}