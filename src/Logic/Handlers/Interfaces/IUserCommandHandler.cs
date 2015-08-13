using System.Collections.Generic;
using Spoofi.FreudBot.Data.Entities;
using Message = Telegram.Bot.Types.Message;

namespace Spoofi.FreudBot.Logic.Handlers.Interfaces
{
    public interface IUserCommandHandler
    {

        void AddCommand(Message message);
        bool Execute(Message message);
        IEnumerable<UserCommand> GetCommandsByChat(int chatId);
    }
}