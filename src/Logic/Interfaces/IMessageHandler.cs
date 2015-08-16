using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Interfaces
{
    public interface IMessageHandler
    {
        void Handle(Message message);
    }
}