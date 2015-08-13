using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers.Interfaces
{
    public interface IMessageHandler
    {
        void Handle(Message message);
    }
}