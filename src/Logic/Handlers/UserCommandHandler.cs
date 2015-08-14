using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using Spoofi.FreudBot.Data.Entities;
using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Bot;
using Spoofi.FreudBot.Logic.Handlers.Interfaces;
using Message = Telegram.Bot.Types.Message;

namespace Spoofi.FreudBot.Logic.Handlers
{
    public class UserCommandHandler : IUserCommandHandler
    {
        private readonly IDatabaseService _db;
        private readonly IBotManager _bot;

        public UserCommandHandler(IDatabaseService databaseService, IBotManager botManager)
        {
            _db = databaseService;
            _bot = botManager;
        }

        public void AddCommand(Message message)
        {
            var text = message.Text.Split(' ').ToList();
            switch (text.Count())
            {
                case 1:
                case 2:
                case 3:
                    const string newLine = "\n\n";
                    const string addCommandHelpText = "Использование команды: " + newLine + " /add /commandName [post|get] url ParamName_1|Param_Value_1 ParamName_2|Param_Value_2" + newLine +
                                                      "Например: /add /ping get http://test.site/api/site/ping page|1" + newLine +
                                                      "Примечание: пока что я не умею возвращать результаты запроса.";
                    _bot.SendText(message.Chat.Id, addCommandHelpText);
                    break;
                default:
                    var newCommand = new UserCommand
                    {
                        Command = text[1],
                        Type = text[2].ToLower() == "post" ? UserCommandType.PostRequest : UserCommandType.GetRequest,
                        ChatId = message.Chat.Id,
                        Url = text[3],
                        Data = GetData(text.Skip(4))
                    };
                    _db.SaveUserCommand(newCommand);
                    _bot.SendText(message.Chat.Id, string.Format("Ок, теперь ты можешь использовать команду {0}", text[1]));
                    break;
            }
        }

        public bool Execute(Message message)
        {
            var userCommand = _db.GetCommandByChat(message.Chat.Id, message.Text);
            if (userCommand == null) return false;
            switch (userCommand.Type)
            {
                case UserCommandType.PostRequest:
                case UserCommandType.GetRequest:
                    Execute(userCommand);
                    break;
            }
            _bot.SendText(message.Chat.Id, "Ок, я выполнил вашу команду :)");
            return true;
        }

        public IEnumerable<string> GetCommandsByChat(int chatId)
        {
            var commands = _db.GetCommandsByChat(chatId).Select(x => x.Command).ToList();
            if (Config.BotAllowedUsers.Contains(chatId))
                commands.Insert(0, "/add");
            return commands;
        }

        private static void Execute(UserCommand userCommand)
        {
            var request = new RestRequest
            {
                Method = userCommand.Type == UserCommandType.PostRequest ? Method.POST : Method.GET
            };
            foreach (var parameter in userCommand.Data)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }
            new RestClient(new Uri(userCommand.Url)).Execute(request);
        }

        private static Dictionary<string, string> GetData(IEnumerable<string> parameters)
        {
            return parameters.ToDictionary(parameter => parameter.Split('|')[0], parameter => parameter.Split('|')[1]);
        }
    }
}