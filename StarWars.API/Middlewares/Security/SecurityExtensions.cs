namespace StarWars.API.Middleares.Security
{
    public static class SecurityExtensions
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
            });

            services.AddAuthorization(auth =>
            {
            });

            return services;
        }

        public static WebApplication UseSecurity(this WebApplication app)
        {
            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(policy => policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

            return app;
        }
    }
}
