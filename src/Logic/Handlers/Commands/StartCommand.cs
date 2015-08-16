using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Bot;
using Spoofi.FreudBot.Logic.Handlers.Interfaces;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers.Commands
{
    public class StartCommand : ICommandStrategy
    {
        private readonly IDatabaseService _db;
        private readonly IBotManager _bot;
        
        public StartCommand(IDatabaseService db, IBotManager bot)
        {
            _db = db;
            _bot = bot;
        }

        public void Execute(Message message)
        {
            if (message.From != null) _db.SaveOrUpdateUserAsync(message.From);
            _bot.SendText(message.Chat.Id, Responses.StartText);
        }
    }
}