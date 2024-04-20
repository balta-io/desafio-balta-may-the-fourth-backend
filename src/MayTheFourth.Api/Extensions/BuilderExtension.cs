using MayTheFourth.Core;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Api.Extensions;

public static class BuilderExtension
{
    public static void AddMediatR(this WebApplicationBuilder builder)
        => builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(Configuration).Assembly));

    public static void AddDbContext(this WebApplicationBuilder builder)
        => builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDatabase"));
}
