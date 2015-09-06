using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Interfaces;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers.Commands
{
    public class ListCommand : ICommandStrategy
    {
        private readonly IBotManager _bot;
        private readonly IDatabaseService _db;
        private readonly ICommandHelper _commandHelper;

        public ListCommand(IBotManager bot, IDatabaseService db, ICommandHelper commandHelper)
        {
            _bot = bot;
            _db = db;
            _commandHelper = commandHelper;
        }

        public void Execute(Message message)
        {
            var commands = _commandHelper.GetCommandsByChat(message.Chat.Id);
            _bot.SendText(message.Chat.Id, string.Format(Responses.ListText, string.Join("\r\n", commands)));
        }
    }
}