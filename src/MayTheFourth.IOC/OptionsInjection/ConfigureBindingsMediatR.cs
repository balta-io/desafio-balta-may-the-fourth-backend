using System.Diagnostics.CodeAnalysis;
using LotoBackend.Application;
using LotoBackend.Application.Common.Behavior;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MayTheFourth.IOC.OptionsInjection
{
    [ExcludeFromCodeCoverage]
    public static class ConfigureBindingsMediatR
    {
        public static void RegisterBindings(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(new AssemblyReference().GetAssembly());
        }
    }
}
