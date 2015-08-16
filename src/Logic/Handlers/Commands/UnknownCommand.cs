using Spoofi.FreudBot.Logic.Bot;
using Spoofi.FreudBot.Logic.Handlers.Interfaces;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers.Commands
{
    public class UnknownCommand : ICommandStrategy
    {
        private readonly IBotManager _bot;

        public UnknownCommand(IBotManager bot)
        {
            _bot = bot;
        }

        public void Execute(Message message)
        {
            _bot.SendText(message.Chat.Id, Responses.UnknownCommandText);
        }
    }
}