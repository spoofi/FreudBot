namespace Spoofi.FreudBot.Logic.Interfaces
{
    public interface IPermissionChecker
    {
        bool Check(int chatId);
    }
}