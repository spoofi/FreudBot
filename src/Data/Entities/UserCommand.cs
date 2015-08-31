using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoRepository;

namespace Spoofi.FreudBot.Data.Entities
{
    [CollectionName("UserCommand")]
    public class UserCommand : Entity
    {
        public int ChatId { get; set; }

        public string Command { get; set; }

        [BsonRepresentation(BsonType.String)]
        public UserCommandType Type { get; set; }

        public string Url { get; set; }

        public Dictionary<string, string> Data { get; set; }

        public string AliasCommand { get; set; }
    }
}