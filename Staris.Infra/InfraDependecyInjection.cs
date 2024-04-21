using Microsoft.Extensions.DependencyInjection;

namespace Staris.Infra;

public static class InfraDependecyInjection
{
    /// <summary>
    /// Responsável por adicionar as dependências a serem resolvidas no projeto de infra
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfraDependencyInjection(this IServiceCollection services)
    {
        return services;
    }
}
