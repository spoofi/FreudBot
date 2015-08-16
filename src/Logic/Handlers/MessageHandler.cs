using System;
using System.Linq;
using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Bot;
using Spoofi.FreudBot.Logic.Handlers.Commands;
using Spoofi.FreudBot.Logic.Interfaces;
using Spoofi.FreudBot.Utils.Extensions;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers
{
    public class MessageHandler : IMessageHandler
    {
        private readonly Lazy<IBotManager> _bot;
        private readonly Lazy<IDatabaseService> _db;
        private readonly Lazy<IPermissionChecker> _permissionChecker;

        public MessageHandler(Lazy<IDatabaseService> databaseService, Lazy<IBotManager> botManager, Lazy<IPermissionChecker> permissionChecker)
        {
            _bot = botManager;
            _db = databaseService;
            _permissionChecker = permissionChecker;
        }

        public void Handle(Message message)
        {
            try
            {
                if (Config.BasicCommands.Contains(message.Text))
                {
                    HandleCommand(message);
                    return;
                }

                if (!_permissionChecker.Value.Check(message.Chat.Id)) return;

                if (message.IsText())
                    HandleText(message);

                if (message.IsCommand())
                    HandleCommand(message);
            }
            catch (Exception exception)
            {
                _db.Value.SaveErrorAsync(exception);
            }
        }

        private void HandleText(Message message)
        {
            
        }

        private void HandleCommand(Message message)
        {
            ICommandStrategy strategy = null;
            switch (message.Text.Split(' ').First())
            {
                case "/start": strategy = new StartCommand(_db.Value, _bot.Value); break;
                case "/help": strategy = new HelpCommand(_permissionChecker.Value, _bot.Value); break;
                case "/settings": strategy = new SettingsCommand(_bot.Value); break;
                case "/add": strategy = new AddCommand(_bot.Value, _db.Value); break;
                case "/list": strategy = new ListCommand(_bot.Value, _db.Value, _permissionChecker.Value); break;
                default:
                    if (_db.Value.GetCommandByChat(message.Chat.Id, message.Text) != null)
                        strategy = new CustomUserCommand(_db.Value, _bot.Value);
                    break;
            }
            new CommandContext(strategy ?? new UnknownCommand(_bot.Value)).Execute(message);
        }
    }
}