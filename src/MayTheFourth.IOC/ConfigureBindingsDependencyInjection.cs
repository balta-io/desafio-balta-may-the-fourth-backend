using System.Diagnostics.CodeAnalysis;
using MayTheFourth.IOC.OptionsInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MayTheFourth.IOC
{
    [ExcludeFromCodeCoverage]
    public static class ConfigureBindingsDependencyInjection
    {
        public static void RegisterBindings
        (
            IServiceCollection services,
            IConfiguration configuration
        )
        {
            ConfigureBindingsMediatR.RegisterBindings(services);
            ConfigureBindingsMongo.RegisterBindings(services, configuration);
            ConfigureBindingsServices.RegisterBindings(services);
            ConfigureBindingsValidator.RegisterBindings(services);
        }
    }
}
