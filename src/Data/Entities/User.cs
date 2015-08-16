using MongoRepository;

namespace Spoofi.FreudBot.Data.Entities
{
    [CollectionName("User")]
    public class User : Entity
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAllowed { get; set; }
    }
}