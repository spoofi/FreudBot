using System;
using System.Linq;
using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Interfaces;
using TelegramMessage = Telegram.Bot.Types.Message;

namespace Spoofi.FreudBot.Logic.Handlers.Commands.Admin
{
    public class AllowUserCommand : ICommandStrategy
    {
        private readonly IBotManager _bot;
        private readonly Lazy<IDatabaseService> _db;

        public AllowUserCommand(IBotManager bot, Lazy<IDatabaseService> db)
        {
            _bot = bot;
            _db = db;
        }

        public void Execute(TelegramMessage message)
        {
            var text = message.Text.Split(' ');
            switch (text.Count())
            {
                case 1:
                    _bot.SendText(message.Chat.Id, Responses.AllowUserCommandUsage);
                    break;
                default:
                    var param = text[1];
                    int userId;
                    var user = int.TryParse(param, out userId) ? _db.Value.UserAllow(userId) : _db.Value.UserAllow(param);
                    if (user == null)
                    {
                        _bot.SendText(message.Chat.Id, Responses.UserNotFound);
                        break;
                    }
                    _bot.SendText(message.Chat.Id, string.Format(Responses.AllowUserCommandSuccessAllowUser, user.GetUsernameWithId()));
                    _bot.SendText(userId, Responses.AllowUserCommandCongratulation);
                    break;
            }
        }
    }
}