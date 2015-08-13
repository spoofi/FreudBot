using System;
using Spoofi.FreudBot.Data.Entities;
using Spoofi.FreudBot.Utils.Extensions;

namespace Spoofi.FreudBot.Data.Mappings
{
    public static class MessageConverter
    {
        public static Message Convert(this Telegram.Bot.Types.Message source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return new Message
            {
                MessageId = source.MessageId,
                ChatId = source.Chat.Id,
                Text = source.Text,
                Date = source.Date,
                Type = source.Text.HasValue() ? TelegramMessageType.Text : TelegramMessageType.Unknown // TODO method for getting type from telegram message
            };
        }
    }
}