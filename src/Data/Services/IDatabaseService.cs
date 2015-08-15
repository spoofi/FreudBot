using System;
using System.Collections.Generic;
using Spoofi.FreudBot.Data.Entities;

namespace Spoofi.FreudBot.Data.Services
{
    public interface IDatabaseService
    {
        Message SaveMessage(Telegram.Bot.Types.Message telegramMessage, bool isReceived = true);

        void SaveOrUpdateUserAsync(Telegram.Bot.Types.User telegramUser);

        void SaveErrorAsync(Exception exception);

        UserCommand GetCommandByChat(int chatId, string command);

        void SaveUserCommand(UserCommand command);

        IEnumerable<UserCommand> GetCommandsByChat(int chatId);
        
    }
}