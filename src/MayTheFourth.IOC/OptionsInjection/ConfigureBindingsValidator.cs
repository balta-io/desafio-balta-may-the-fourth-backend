using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using MayTheFourth.Application;
using Microsoft.Extensions.DependencyInjection;

namespace MayTheFourth.IOC.OptionsInjection
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
