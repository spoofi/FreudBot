using Spoofi.FreudBot.Logic.Bot;
using Spoofi.FreudBot.Logic.Interfaces;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers.Commands
{
    public class SettingsCommand : ICommandStrategy
    {
        private readonly IBotManager _bot;

        public SettingsCommand(IBotManager bot)
        {
            _bot = bot;
        }

        public void Execute(Message message)
        {
            _bot.SendText(message.Chat.Id, Responses.SettingsText);
        }
    }
}