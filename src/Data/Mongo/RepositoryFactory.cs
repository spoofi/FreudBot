using System.Configuration;
using MongoRepository;

namespace Spoofi.FreudBot.Data.Mongo
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly string _connectionString;

        public RepositoryFactory()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["mongo"].ConnectionString;
        }

        public RepositoryFactory(string connectionString)
        {
            _connectionString = connectionString ?? ConfigurationManager.ConnectionStrings["mongo"].ConnectionString;
        }

        public MongoRepository<T> GetRepository<T>() where T : Entity
        {
            return new MongoRepository<T>(_connectionString);
        }
    }
}