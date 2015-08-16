using System.Linq;
using Spoofi.FreudBot.Data.Services;
using Spoofi.FreudBot.Logic.Bot;
using Spoofi.FreudBot.Logic.Interfaces;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers.Commands
{
    public class ListCommand : ICommandStrategy
    {
        private readonly IBotManager _bot;
        private readonly IDatabaseService _db;
        private readonly IPermissionChecker _permissionChecker;

        public ListCommand(IBotManager bot, IDatabaseService db, IPermissionChecker permissionChecker)
        {
            _bot = bot;
            _db = db;
            _permissionChecker = permissionChecker;
        }

        public void Execute(Message message)
        {
            var commands = Config.BasicCommands.ToList();
            var userCommands = _db.GetCommandsByChat(message.Chat.Id).Select(x => x.Command).ToList();
            if (_permissionChecker.Check(message.Chat.Id))
                userCommands.Insert(0, "/add"); // TODO extract to Config.AllowedUsersCommands
            commands.AddRange(userCommands);
            _bot.SendText(message.Chat.Id, string.Format(Responses.ListText, string.Join("\r\n", commands)));
        }
    }
}