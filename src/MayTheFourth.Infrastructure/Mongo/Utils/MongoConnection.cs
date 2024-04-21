using MayTheFourth.Infrastructure.Mongo.Utils.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace MayTheFourth.Infrastructure.Mongo.Utils
{
    public class MongoConnection(IOptions<MongoConnectionOptions> options) : IMongoConnection
    {
        private static readonly object Lock = new();

        private bool _isRegistered = false;

        private readonly Dictionary<string, IMongoDatabase> Databases = [];

        private readonly string _connectionString = options.Value.ConnectionString!;

        private readonly string _defaultDatabaseName = options.Value.Schema!;

        public IMongoDatabase GetDatabase()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentNullException(_connectionString, "Mongo ConnectionString is Null.");
            }

            lock (Lock)
            {
                Databases.TryGetValue(_connectionString, out var database);

                if (database != null) return database;

                var urlBuilder = new MongoUrlBuilder(_connectionString);
                var databaseName = urlBuilder.DatabaseName;

                if (database == null && string.IsNullOrEmpty(_defaultDatabaseName))
                {
                    throw new ArgumentNullException(databaseName, "Mongo Default Database is Null.");
                }

                databaseName = _defaultDatabaseName;

                var client = new MongoClient(urlBuilder.ToMongoUrl());
                database = client.GetDatabase(databaseName);

                Register();

                Databases[_connectionString] = database;

                return database;
            }
        }

        private void Register()
        {
            var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
            ConventionRegistry.Register("IgnoreElements", conventionPack, _ => true);

            if (!_isRegistered)
            {
                BsonSerializer.RegisterSerializer(typeof(DateTime), new UtcDateTimeSerializer());
                _isRegistered = true;
            }
        }
    }
}
