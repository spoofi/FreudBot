namespace Spoofi.FreudBot.Logic.Bot
{
    public interface IBotManager
    {
        void SendText(int chatId, string text);
    }
}