using System.Diagnostics.CodeAnalysis;
using LotoBackend.IOC.OptionsInjection;
using MayTheFourth.IOC.OptionsInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LotoBackend.IOC
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
            ConfigureBindingsValidator.RegisterBindings(services);
        }
    }
}
