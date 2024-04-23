using System.Diagnostics.CodeAnalysis;
using Mapster;
using MayTheFourth.Application;

namespace MayTheFourth.IOC.OptionsInjection
{
    [ExcludeFromCodeCoverage]
    public static class ConfigureBindingsMapping
    {
        public static void RegisterBindings()
        {
            TypeAdapterConfig.GlobalSettings.Scan(new AssemblyReference().GetAssembly());
        }
    }
}
