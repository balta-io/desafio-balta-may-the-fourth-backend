using MayTheFourth.Core;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Configuration;

namespace MayTheFourth.Api.Extensions;

public static class BuilderExtension
{

    public static void AddConfiguration(this WebApplicationBuilder builder)
        => Configuration.Database.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

    public static void AddMediatR(this WebApplicationBuilder builder)
    => builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(Configuration).Assembly));

    public static void AddDbContext(this WebApplicationBuilder builder)
        => builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.Database.ConnectionString, assembly => assembly.MigrationsAssembly("MayTheFourth.Api"))
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));

            });

    //public static void AddDbContext(this WebApplicationBuilder builder)
    //    => builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDatabase"));
}
