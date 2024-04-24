using MayTheFourth.Application.Common.AppServices.PopulateDB;
using MayTheFourth.Application.Common.AppServices.PopulateFilms;
using MayTheFourth.Application.Common.AppServices.PopulatePeople;
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
            services.AddScoped<IPopulateFilmsResponseAppService, PopulateFilmsResponseAppService>();
            services.AddScoped<IPopulatePeopleResponseAppService, PopulatePeopleResponseAppService>();
        }
    }
}
