using System;
using System.Linq;
using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Bot;
using Spoofi.FreudBot.Logic.Handlers.Interfaces;
using Spoofi.FreudBot.Utils.Extensions;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers
{
    public class MessageHandler : IMessageHandler
    {
        private readonly IBotManager _bot;
        private readonly IDatabaseService _db;
        private readonly IUserCommandHandler _commandHandler;

        public MessageHandler(IDatabaseService databaseService, IBotManager botManager, IUserCommandHandler commandHandler)
        {
            _bot = botManager;
            _db = databaseService;
            _commandHandler = commandHandler;
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

                if (!CheckPermission(message)) return;

                if (message.IsText())
                    HandleText(message);

                if (message.IsCommand())
                    HandleCommand(message);
            }
            catch (Exception exception)
            {
                _db.SaveError(exception);
            }
        }

        private static bool CheckPermission(Message message)
        {
            return Config.BotAllowedUsers.Contains(message.Chat.Id);
        }

        private void HandleText(Message message)
        {
            
        }

        private void HandleCommand(Message message)
        {
            switch (message.Text.Split(' ').First())
            {
                case "/start":
                    _bot.SendText(message.Chat.Id, Responses.MessageHandler_HandleCommand_start);
                    break;
                case "/help":
                    _bot.SendText(message.Chat.Id, string.Format(Responses.MessageHandler_HandleCommand_help, message.Chat.Id));
                    break;
                case "/settings":
                    _bot.SendText(message.Chat.Id, Responses.MessageHandler_HandleCommand_settings);
                    break;
                case "/add":
                    _commandHandler.AddCommand(message);
                    break;
                case "/list":
                    var commands = Config.BasicCommands.ToList();
                    commands.AddRange(_commandHandler.GetCommandsByChat(message.Chat.Id));
                    _bot.SendText(message.Chat.Id, string.Format(Responses.MessageHandler_HandleCommand_list, string.Join("\n", commands)));
                    break;
                default:
                    if (_commandHandler.Execute(message))
                        break;
                    _bot.SendText(message.Chat.Id, Responses.MessageHandler_HandleCommand_unknown_command);
                    break;
            }
        }
    }
}