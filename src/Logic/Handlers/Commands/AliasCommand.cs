using System;
using System.Collections.Generic;
using System.Linq;
using Spoofi.FreudBot.Data.Entities;
using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Interfaces;
using Spoofi.FreudBot.Utils.Extensions;
using Message = Telegram.Bot.Types.Message;

namespace Spoofi.FreudBot.Logic.Handlers.Commands
{
    public class AliasCommand : ICommandStrategy
    {
        private readonly IDatabaseService _db;
        private readonly IBotManager _bot;
        private readonly ICommandHelper _commandHelper;

        public AliasCommand(IDatabaseService databaseService, IBotManager botManager, ICommandHelper commandHelper)
        {
            _db = databaseService;
            _bot = botManager;
            _commandHelper = commandHelper;
        }

        public void Execute(Message message)
        {
            var parameters = message.GetCommandParams();
            if (parameters.Length == 0)
            {
                _bot.SendText(message.Chat.Id, Responses.AliasCommand_Usage);
                return;
            }
            switch (parameters[0])
            {
                case "add":
                    if (!ValidateAdd(parameters.Skip(2).ToArray(), message.Chat.Id))
                        return;
                    var alias = new UserCommand
                    {
                        Type = UserCommandType.Alias,
                        Command = parameters[1],
                        AliasCommand = parameters.Skip(2).Join(" "),
                        ChatId = message.Chat.Id
                    };
                    _db.SaveUserCommand(alias);
                    _bot.SendText(message.Chat.Id, Responses.AliasCommand_AliasSaved);
                    break;
                case "del": break;
                case "list": break;
                default:
                    _bot.SendText(message.Chat.Id, Responses.AliasCommand_Usage);
                    break;
            }
        }

        private bool ValidateAdd(string[] addParameters, int chatId)
        {
            if (!addParameters.Any())
            {
                _bot.SendText(chatId, Responses.AliasCommand_Usage);
                return false;
            }
            var command = addParameters.First();
            if (_commandHelper.GetCommandsByChat(chatId).Contains(command)) return true;
            _bot.SendText(chatId, string.Format(Responses.AliasCommand_ValidateAdd_CommandNotFound, command));
            return false;
        }
    }
}