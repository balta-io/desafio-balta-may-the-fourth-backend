using System.Diagnostics.CodeAnalysis;
using MayTheFourth.Infrastructure.Mongo.Contexts;
using MayTheFourth.Infrastructure.Mongo.Contexts.Interfaces;
using MayTheFourth.Infrastructure.Mongo.Utils;
using MayTheFourth.Infrastructure.Mongo.Utils.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MayTheFourth.IOC.OptionsInjection
{
    [ExcludeFromCodeCoverage]
    public static class ConfigureBindingsMongo
    {
        public static void RegisterBindings
        (
            IServiceCollection services,
            IConfiguration configuration
        )
        {
            //services.Configure<MongoConnectionOptions>(c =>
            //{
            //    int defaultTtlDays = configuration.GetValue<int>("Mongo:DefaultTtlDays");
            //    c.DefaultTtlDays = defaultTtlDays == default ? 30 : defaultTtlDays;

            //    c.ConnectionString = configuration.GetValue<string>("Mongo:ConnectionString");

            //    c.Schema = configuration.GetValue<string>("Mongo:Schema");
            //});

            services.AddSingleton<IMongoConnection, MongoConnection>();
            services.AddSingleton<IMongoContext, MongoContext>();

            ConfigureMongoRepositories(services);
            ConfigureMongoSerializer();
        }

        private static void ConfigureMongoRepositories(IServiceCollection services)
        {
            //Example
            //services.AddScoped<IRepository<ClienteEntity>, GenericRepository<ClienteEntity>>();            
        }

        private static void ConfigureMongoSerializer()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            #pragma warning disable 618
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;
            BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
            #pragma warning restore

            #pragma warning disable CS8602
            var objectSerializer = new ObjectSerializer
            (
               type =>
                       ObjectSerializer.DefaultAllowedTypes(type) ||
                       type.FullName.StartsWith("MayTheFourth.Domain")
            );
            #pragma warning restore CS8602

            BsonSerializer.RegisterSerializer(objectSerializer);
        }
    }
}
