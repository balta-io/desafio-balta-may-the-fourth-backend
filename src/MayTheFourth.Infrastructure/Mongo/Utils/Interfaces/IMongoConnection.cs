using MongoDB.Driver;

namespace MayTheFourth.Infrastructure.Mongo.Utils.Interfaces
{
    public interface IMongoConnection
    {
        IMongoDatabase GetDatabase();
    }
}
