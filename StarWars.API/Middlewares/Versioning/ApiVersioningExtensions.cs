using Asp.Versioning;

namespace StarWars.API.Middleares.Versioning
{
    public static class ApiVersioningExtensions
    {
        public static IServiceCollection AddApiVersioningConfig(this IServiceCollection services)
        {
            services.AddApiVersioning(
           options =>
           {
               options.ReportApiVersions = true;
               options.DefaultApiVersion = new ApiVersion(1, 1);

           })
           .AddApiExplorer(
           options =>
           {
               options.GroupNameFormat = "'v'VVV";
               options.SubstituteApiVersionInUrl = true;
           }).EnableApiVersionBinding();

            return services;
        }
    }
}
