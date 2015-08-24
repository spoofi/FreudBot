using System;
using System.Collections.Generic;
using System.Linq;
using Spoofi.FreudBot.Logic.Interfaces;
using Spoofi.FreudBot.Logic.Utils;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Logic.Handlers.Commands
{
    public class WolCommand : ICommandStrategy
    {
        private readonly IBotManager _bot;

        public WolCommand(IBotManager bot)
        {
            _bot = bot;
        }

        public void Execute(Message message)
        {
            var text = message.Text.Split(' ');
            switch (text.Count())
            { // /wol 1.2.3.4 00:00:00:00:00:55 7
                case 1:
                case 2:
                    _bot.SendText(message.Chat.Id, Responses.WolCommandUsageText);
                    break;
                default:
                    if (!WakeOnLan.ValidateMac(text[2]))
                        _bot.SendText(message.Chat.Id, Responses.WolCommandIncorrectMac);
                    else
                    {
                        try
                        {
                            WakeOnLan.Up(text[1], text[2], GetPort(text));
                            _bot.SendText(message.Chat.Id, Responses.WolCommandSuccessExecuteText);
                        }
                        catch (Exception)
                        {
                            _bot.SendText(message.Chat.Id, Responses.WolCommandFailExecuteText);
                        }
                    }
                    break;
            }
        }

        private static int? GetPort(IReadOnlyList<string> text)
        {
            int port;
            if (text.Count == 4 && int.TryParse(text[3], out port))
                return port;
            return null;
        }
    }
}