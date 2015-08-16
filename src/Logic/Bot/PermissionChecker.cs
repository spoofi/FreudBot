using System.Linq;
using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Interfaces;

namespace Spoofi.FreudBot.Logic.Bot
{
    public class PermissionChecker : IPermissionChecker
    {
        private readonly IDatabaseService _db;

        public PermissionChecker(IDatabaseService db)
        {
            _db = db;
        }

        public bool Check(int chatId)
        {
            return _db.GetAllowedUsers().Select(u => u.UserId).Contains(chatId) || Config.BotAdmins.Contains(chatId);
        }
    }
}