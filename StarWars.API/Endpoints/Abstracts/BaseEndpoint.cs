using Asp.Versioning;

namespace StarWars.API.Endpoints.Abstracts
{
    public static class BaseEndpoint
    {
        public static WebApplication UseEndpoints(this WebApplication app)
        {
            var route = app.NewVersionedApi()
                       .MapGroup("/v{version:apiVersion}")
                       .HasApiVersion(new ApiVersion(1, 1));

            route.StarWarsEndpoints("/startwars")
                 .ImportEndpoints("/import");

            return app;
        }
    }
}

