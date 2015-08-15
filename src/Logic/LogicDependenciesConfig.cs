using LightInject;
using Spoofi.FreudBot.Data;
using Spoofi.FreudBot.Logic.Bot;
using Spoofi.FreudBot.Logic.Handlers;
using Spoofi.FreudBot.Logic.Handlers.Interfaces;

namespace Spoofi.FreudBot.Logic
{
    public static class LogicDependenciesConfig
    {
        public static void Register(ServiceContainer container)
        {
            container.Register<IBotManager, BotManager>();
            container.Register<IMessageHandler, MessageHandler>();
            container.Register<IUserCommandHandler, UserCommandHandler>();
            DataDependenciesConfig.Register(container);
        }
    }
}