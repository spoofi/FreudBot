using System;
using RestSharp;
using Spoofi.FreudBot.Data.Entities;
using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Interfaces;
using Message = Telegram.Bot.Types.Message;

namespace Spoofi.FreudBot.Logic.Handlers.Commands
{
    public class CustomUserCommand : ICommandStrategy
    {
        private readonly IDatabaseService _db;
        private readonly IBotManager _bot;

        public CustomUserCommand(IDatabaseService databaseService, IBotManager botManager)
        {
            _db = databaseService;
            _bot = botManager;
        }

        public void Execute(Message message)
        {
            var userCommand = _db.GetCommandByChat(message.Chat.Id, message.Text);
            switch (userCommand.Type)
            {
                case UserCommandType.PostRequest:
                case UserCommandType.GetRequest:
                    ExecuteRequestCommand(userCommand);
                    break;
                case UserCommandType.Alias:
                    _bot.SendText(message.Chat.Id, "test");
                    return;
            }
            _bot.SendText(message.Chat.Id, Responses.UserCommandSuccessRun);
        }

        private static void ExecuteRequestCommand(UserCommand userCommand)
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
    }
}