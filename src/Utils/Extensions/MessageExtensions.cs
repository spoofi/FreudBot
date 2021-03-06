﻿using System.Linq;
using Telegram.Bot.Types;

namespace Spoofi.FreudBot.Utils.Extensions
{
    public static class MessageExtensions
    {
        public static bool IsText(this Message message)
        {
            return message.Text.HasValue() && message.Text[0] != '/';
        }

        public static bool IsCommand(this Message message)
        {
            return message.Text.HasValue() && message.Text[0] == '/';
        }

        public static string GetCommand(this Message message)
        {
            return message.IsCommand() ? message.Text.Split(' ').FirstOrDefault() : null;
        }

        public static string[] GetCommandParams(this Message message)
        {
            return message.IsCommand() ? message.Text.Split(' ').Skip(1).ToArray() : new string[0];
        }
    }
}