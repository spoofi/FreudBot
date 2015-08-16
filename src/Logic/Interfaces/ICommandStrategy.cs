using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Interfaces
{
    public interface ICommandStrategy
    {
        void Execute(Message message);
    }
}