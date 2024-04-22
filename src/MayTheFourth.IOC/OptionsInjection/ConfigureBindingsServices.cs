using MayTheFourth.Application.Common.AppServices;
using MayTheFourth.Application.Common.Services;
using MayTheFourth.Infrastructure.StarWarsApi;
using Microsoft.Extensions.DependencyInjection;

namespace MayTheFourth.IOC.OptionsInjection
{
    public static class ConfigureBindingsServices
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddScoped<IStarWarsApiService, StarWarsApiService>();
            services.AddScoped<IPopulateSWDataBaseAppService, PopulateSWDataBaseAppService>();
        }
    }
}
