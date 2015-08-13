namespace Spoofi.FreudBot.Data.Entities
{
    public enum TelegramMessageType
    {
        Unknown,
        Text,
        Audio,
        Document,
        Photo,
        Sticker,
        Video,
        Contact,
        Location,
        NewChatParticipant,
        LeftChatParticipant,
        NewChatTitle,
        NewChatPhoto,
        DeleteChatPhoto,
        GroupChatCreated,
    }
}