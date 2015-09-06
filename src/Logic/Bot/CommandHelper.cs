using System.Collections.Generic;
using System.Linq;
using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Interfaces;

namespace Spoofi.FreudBot.Logic.Bot
{
    public class CommandHelper : ICommandHelper
    {
        private readonly IDatabaseService _db;

        public CommandHelper(IDatabaseService db)
        {
            _db = db;
        }

        public bool CheckPermission(int chatId)
        {
            return _db.GetAllowedUsers().Select(u => u.UserId).Contains(chatId) || Config.BotAdmins.Contains(chatId);
        }

        public IEnumerable<string> GetCommandsByChat(int chatId)
        {
            var commands = Config.BasicCommands.ToList();
            var userCommands = _db.GetCommandsByChat(chatId).Select(x => x.Command).ToList();
            if (CheckPermission(chatId))
                userCommands.InsertRange(0, Config.UserCommands);
            commands.AddRange(userCommands);
            return commands;
        }
    }
}