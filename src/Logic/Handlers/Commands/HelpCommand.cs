using Spoofi.FreudBot.Logic.Bot;
using Spoofi.FreudBot.Logic.Handlers.Interfaces;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers.Commands
{
    public class HelpCommand : ICommandStrategy
    {
        private readonly IPermissionChecker _permissionChecker;
        private readonly IBotManager _bot;

        public HelpCommand(IPermissionChecker permissionChecker, IBotManager bot)
        {
            _permissionChecker = permissionChecker;
            _bot = bot;
        }

        public void Execute(Message message)
        {
            _bot.SendText(message.Chat.Id, _permissionChecker.Check(message.Chat.Id) ? Responses.HelpTextForAllowed : string.Format(Responses.HelpText, message.Chat.Id));
        }
    }
}