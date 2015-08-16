using System.Collections.Generic;
using System.Linq;
using Spoofi.FreudBot.Data.Entities;
using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Bot;
using Spoofi.FreudBot.Logic.Interfaces;
using Message = Telegram.Bot.Types.Message;

namespace Spoofi.FreudBot.Logic.Handlers.Commands
{
    public class AddCommand : ICommandStrategy
    {
        private readonly IBotManager _bot;
        private readonly IDatabaseService _db;

        public AddCommand(IBotManager bot, IDatabaseService db)
        {
            _bot = bot;
            _db = db;
        }

        public void Execute(Message message)
        {
            var text = message.Text.Split(' ');
            switch (text.Count())
            {
                case 1:
                case 2:
                case 3:
                    _bot.SendText(message.Chat.Id, Responses.AddCommandUsageText);
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
                    _bot.SendText(message.Chat.Id, string.Format(Responses.AddCommandSuccesfullyAddedCommand, text[1]));
                    break;
            }
        }

        private static Dictionary<string, string> GetData(IEnumerable<string> parameters)
        {
            return parameters.ToDictionary(parameter => parameter.Split('|')[0], parameter => parameter.Split('|')[1]);
        }
    }
}