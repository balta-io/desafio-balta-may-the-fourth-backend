using Microsoft.Extensions.DependencyInjection;

namespace Staris.Domain;

public static class DomainDependecyInjection
{
    /// <summary>
    /// Responsável por adicionar as dependências a serem resolvidas no projeto de infra
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddDomainDependencyInjection(this IServiceCollection services)
    {
        return services;
    }
}
