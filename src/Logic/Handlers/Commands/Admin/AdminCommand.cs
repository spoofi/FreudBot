using Spoofi.FreudBot.Logic.Bot;
using Spoofi.FreudBot.Logic.Interfaces;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers.Commands.Admin
{
    public class AdminCommand : ICommandStrategy
    {
        private readonly IBotManager _bot;

        public AdminCommand(IBotManager bot)
        {
            _bot = bot;
        }

        public void Execute(Message message)
        {
            _bot.SendText(message.Chat.Id, string.Format(Responses.AdminText, string.Join("\r\n", Config.AdminCommands)));
        }
    }
}