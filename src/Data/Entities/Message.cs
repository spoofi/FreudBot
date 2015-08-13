using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoRepository;

namespace Spoofi.FreudBot.Data.Entities
{
    [CollectionName("Message")]
    public class Message : Entity
    {
        public int MessageId { get; set; }

        public int ChatId { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }

        [BsonRepresentation(BsonType.String)]
        public TelegramMessageType Type { get; set; }

        [BsonDefaultValue(true)]
        public bool IsReceived { get; set; }
    }
}