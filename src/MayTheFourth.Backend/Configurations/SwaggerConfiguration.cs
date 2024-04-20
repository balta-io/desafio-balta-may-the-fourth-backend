using Microsoft.OpenApi.Models;

namespace MayTheFourth.Backend.Configurations
{
    public static class SwaggerConfiguration
    {
        private const string ApiTitle = "May The Fourth API";
        private const int ApiVersion = 1;

        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc($"v{ApiVersion}", new OpenApiInfo
                {
                    Title = ApiTitle,
                    Version = $"v{ApiVersion}"
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v{ApiVersion}/swagger.json", ApiTitle);
            });

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
