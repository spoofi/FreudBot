using System.Collections.Generic;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers.Interfaces
{
    public interface IUserCommandHandler
    {

        void AddCommand(Message message);
        bool Execute(Message message);
        IEnumerable<string> GetCommandsByChat(int chatId);
    }
}