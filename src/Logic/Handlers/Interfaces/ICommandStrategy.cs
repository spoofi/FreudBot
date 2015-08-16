using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers.Interfaces
{
    public interface ICommandStrategy
    {
        void Execute(Message message);
    }
}