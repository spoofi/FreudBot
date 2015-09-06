using System.Collections.Generic;

namespace Spoofi.FreudBot.Logic.Interfaces
{
    public interface ICommandHelper
    {
        bool CheckPermission(int chatId);
        IEnumerable<string> GetCommandsByChat(int chatId);
    }
}