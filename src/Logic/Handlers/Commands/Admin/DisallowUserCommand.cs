using System;
using System.Linq;
using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Interfaces;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers.Commands.Admin
{
    public class DisallowUserCommand : ICommandStrategy
    {
        private readonly IBotManager _bot;
        private readonly Lazy<IDatabaseService> _db;

        public DisallowUserCommand(IBotManager bot, Lazy<IDatabaseService> db)
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
                    _bot.SendText(message.Chat.Id, Responses.DisallowUserCommandUsage);
                    break;
                default:
                    var param = text[1];
                    int userId;
                    var user = int.TryParse(param, out userId) ? _db.Value.UserDisallow(userId) : _db.Value.UserDisallow(param);
                    if (user == null)
                    {
                        _bot.SendText(message.Chat.Id, Responses.UserNotFound);
                        break;
                    }
                    _bot.SendText(message.Chat.Id, string.Format(Responses.DisallowUserCommandSuccess, user.GetUsernameWithId()));
                    _bot.SendText(userId, Responses.DisallowUserCommandMessageToUser);
                    break;
            }
        }
    }
}