using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Interfaces;
using Spoofi.FreudBot.Utils.Extensions;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers.Commands
{
    public class AliasCommand : ICommandStrategy
    {
        private readonly IDatabaseService _db;
        private readonly IBotManager _bot;

        public AliasCommand(IDatabaseService databaseService, IBotManager botManager)
        {
            _db = databaseService;
            _bot = botManager;
        }

        public void Execute(Message message)
        {
            var parameters = message.GetCommandParams();
            if (parameters.Length == 0)
            {
                _bot.SendText(message.Chat.Id, ""); //TODO help text for alias command
                return;
            }
            switch (parameters[0])
            {
                case "add":

                    break;
                case "del": break;
                case "list": break;
                default:
                    _bot.SendText(message.Chat.Id, ""); //TODO 1 parameter not exist -> help
                    break;
            }
        }
    }
}