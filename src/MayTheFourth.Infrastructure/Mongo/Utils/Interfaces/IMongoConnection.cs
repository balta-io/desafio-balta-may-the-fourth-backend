using MongoDB.Driver;

namespace LotoBackend.Infrastructure.Mongo.Utils.Interfaces
{
    public interface IMongoConnection
    {
        IMongoDatabase GetDatabase();
    }
}
