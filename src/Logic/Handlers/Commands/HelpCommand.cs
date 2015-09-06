using Spoofi.FreudBot.Logic.Interfaces;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers.Commands
{
    public class HelpCommand : ICommandStrategy
    {
        private readonly ICommandHelper _commandHelper;
        private readonly IBotManager _bot;

        public HelpCommand(ICommandHelper commandHelper, IBotManager bot)
        {
            _commandHelper = commandHelper;
            _bot = bot;
        }

        public void Execute(Message message)
        {
            _bot.SendText(message.Chat.Id, _commandHelper.CheckPermission(message.Chat.Id) ? Responses.HelpTextForAllowed : string.Format(Responses.HelpText, message.Chat.Id));
        }
    }
}