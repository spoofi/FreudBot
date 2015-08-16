using MongoRepository;
using Spoofi.FreudBot.Utils.Extensions;

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

        public string GetUsername()
        {
            return UserName.HasValue() ? UserName : string.Format("{0} {1}", FirstName, LastName);
        }

        public string GetUsernameWithId()
        {
            return string.Format("{0} ({1})", GetUsername(), UserId);
        }
    }
}