using System;
using MongoRepository;

namespace Spoofi.FreudBot.Data.Entities
{
    [CollectionName("Error")]
    public class Error : Entity
    {
        public DateTime Date { get; set; }

        public string Message { get; set; }

        public string Stacktrace { get; set; }
    }
}