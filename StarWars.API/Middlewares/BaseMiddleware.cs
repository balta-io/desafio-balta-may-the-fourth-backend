using StarWars.API.Middleares.Json;
using StarWars.API.Middleares.Security;
using StarWars.API.Middleares.Swagger;
using StarWars.API.Middleares.Versioning;

namespace StarWars.API.Middlewares
{
    public static class BaseMiddleware
	{
		public static IServiceCollection AddMiddlewares(
			this IServiceCollection services)
		{
            services.AddCors();
            services.AddLogging();
            services.AddSecurity();
            services.AddJsonConfig();
            services.AddSwaggerDocs();
            services.AddApiVersioningConfig();

            return services;
		}

		public static WebApplication UseMiddlewares(this WebApplication app)
		{
			app.UseSecurity();
			app.UseSwaggerDocs();

            return app;
		}
    }
}

