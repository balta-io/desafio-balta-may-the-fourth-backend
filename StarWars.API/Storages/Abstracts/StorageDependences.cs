using Microsoft.EntityFrameworkCore;
using StarWars.API.Storages.Datas;
using StarWars.API.Storages.Repositores;

namespace StarWars.API.Storages.Abstracts
{
    public static class StorageDependences
    {
        public static IServiceCollection AddStorageDependences(
            this IServiceCollection services, IConfiguration configuration)
        {
            var mySqlConnection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<StarWarsContext>();

            services.AddScoped<IStarWarsRepository, StarWarsRepository>();

            return services;
        }
    }
}

