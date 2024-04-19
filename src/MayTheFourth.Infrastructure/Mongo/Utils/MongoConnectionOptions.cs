namespace LotoBackend.Infrastructure.Mongo.Utils
{
    public class MongoConnectionOptions
    {
        public string? ConnectionString { get; set; }
        public string? Schema { get; set; }
        public int DefaultTtlDays { get; set; }
    }
}
