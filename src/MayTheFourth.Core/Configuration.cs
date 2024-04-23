namespace MayTheFourth.Core;

public static class Configuration
{
    public static DatabaseConfiguration Database { get; set; } = new();


    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;
    }
}
