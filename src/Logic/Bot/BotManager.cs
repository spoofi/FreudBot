using Telegram.Bot;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Bot
{
    public class BotManager : IBotManager
    {
        private static Api _bot;
        private Message _result;

        public BotManager()
        {
            _bot = Bot.Get();
        }

        public void SendText(int chatId, string text)
        {
            _result =_bot.SendTextMessage(chatId, text).Result;
        }
    }
}