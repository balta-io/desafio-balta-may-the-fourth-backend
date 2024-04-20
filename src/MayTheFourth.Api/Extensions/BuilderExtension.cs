using MayTheFourth.Core;

namespace MayTheFourth.Api.Extensions;

public static class BuilderExtension
{
    public static void AddMediatR(this WebApplicationBuilder builder)
        => builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssembly(typeof(Configuration).Assembly));
}
