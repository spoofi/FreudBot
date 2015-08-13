namespace Spoofi.FreudBot.Logic.Bot
{
    public interface IBotManager
    {
        void SendText(int chatId, string text);
        void RequestData(int chatId, string text, int replyTo);
    }
}