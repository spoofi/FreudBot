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
        private readonly IBotManager _bot;
        private readonly IDatabaseService _db;
        private readonly IPermissionChecker _permissionChecker;

        public MessageHandler(IDatabaseService databaseService, IBotManager botManager, IPermissionChecker permissionChecker)
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

                if (!_permissionChecker.Check(message.Chat.Id)) return;

                if (message.IsText())
                    HandleText(message);

                if (message.IsCommand())
                    HandleCommand(message);
            }
            catch (Exception exception)
            {
                _db.SaveErrorAsync(exception);
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
                case "/start": strategy = new StartCommand(_db, _bot); break;
                case "/help": strategy = new HelpCommand(_permissionChecker, _bot); break;
                case "/settings": strategy = new SettingsCommand(_bot); break;
                case "/add": strategy = new AddCommand(_bot, _db); break;
                case "/list": strategy = new ListCommand(_bot, _db, _permissionChecker); break;
                default:
                    if (_db.GetCommandByChat(message.Chat.Id, message.Text) != null)
                        strategy = new CustomUserCommand(_db, _bot);
                    break;
            }
            new CommandContext(strategy ?? new UnknownCommand(_bot)).Execute(message);
        }
    }
}