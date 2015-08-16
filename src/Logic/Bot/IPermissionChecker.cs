namespace Spoofi.FreudBot.Logic.Bot
{
    public interface IPermissionChecker
    {
        bool Check(int chatId);
    }
}