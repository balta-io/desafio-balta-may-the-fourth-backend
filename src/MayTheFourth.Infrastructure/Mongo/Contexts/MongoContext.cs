using LotoBackend.Infrastructure.Mongo.Contexts.Interfaces;
using LotoBackend.Infrastructure.Mongo.Utils;
using LotoBackend.Infrastructure.Mongo.Utils.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LotoBackend.Infrastructure.Mongo.Contexts
{
    public class MongoContext
    (
        IMongoConnection mongoConnection,
        IOptions<MongoConnectionOptions> options
    ) : IMongoContext
    {
        private readonly IMongoConnection _connection = mongoConnection;

        public int DefaultTtlDays { get; set; } = options.Value.DefaultTtlDays;

        public IMongoDatabase GetDatabase() => _connection.GetDatabase();

        public IMongoCollection<T> GetCollection<T>(string? name = null)
        {
            var database = _connection.GetDatabase();

            var collection = name != null
                ? database.GetCollection<T>(name)
                : GetCollection<T>(database);

            return collection;
        }

        public static IMongoCollection<T> GetCollection<T>(IMongoDatabase database)
        {
            var attrs = typeof(T).GetCustomAttributes(typeof(CollectionNameAttribute), false)
                                 .OfType<CollectionNameAttribute>().FirstOrDefault();

            var collectionName = attrs?.Name ?? typeof(T).Name;

            return database.GetCollection<T>(collectionName);
        }
    }
}
