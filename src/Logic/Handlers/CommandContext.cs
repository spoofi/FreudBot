using Spoofi.FreudBot.Logic.Handlers.Interfaces;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers
{
    public class CommandContext
    {
        private ICommandStrategy _strategy;

        public CommandContext(ICommandStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Execute(Message message)
        {
            _strategy.Execute(message);
        }

        public void SetStrategy(ICommandStrategy strategy)
        {
            _strategy = strategy;
        }
    }
}