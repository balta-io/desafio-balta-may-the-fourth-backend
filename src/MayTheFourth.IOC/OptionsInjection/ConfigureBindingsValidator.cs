using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using LotoBackend.Application;
using Microsoft.Extensions.DependencyInjection;

namespace LotoBackend.IOC.OptionsInjection
{
    [ExcludeFromCodeCoverage]
    public static class ConfigureBindingsValidator
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(new AssemblyReference().GetAssembly());
        }
    }
}
