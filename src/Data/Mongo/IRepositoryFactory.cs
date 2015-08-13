using MongoRepository;

namespace Spoofi.FreudBot.Data.Mongo
{
    public interface IRepositoryFactory
    {
        MongoRepository<T> GetRepository<T>() where T : Entity;
    }
}