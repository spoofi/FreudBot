using System;
using System.Linq;
using Telegram.Bot;

namespace Spoofi.FreudBot.Logic.Bot
{
    public static class Bot
    {
        private static Api _bot;
        public static DateTime StartedAtUtc;

        public static Api Get()
        {
            if (_bot != null) return _bot;
            _bot = new Api(Config.BotApiKey);
            _bot.SetWebhook(Config.WebHookUrl);

            if (Config.BotAdmins.Any())
                StartedAtUtc = _bot.SendTextMessage(Config.BotAdmins.First(), "I'm initialized and ready for work!").Result.Date.ToUniversalTime();

            return _bot;
        }
    }
}