using MayTheFourth.Endpoints;

namespace MayTheFourth.Mappings.Filme;

/// <summary>
/// Fornece uma configuração centralizada para mapeamento de endpoints de filmes na aplicação web.
/// </summary>
public static class FilmeMapping
{
    /// <summary>
    /// Registra os endpoints de filmes na aplicação, definindo rotas para operações de obtenção e postagem de dados de filmes.
    /// </summary>
    /// <param name="app">A instância da aplicação web na qual os endpoints serão registrados.</param>
    public static void FilmeMapEndpoints(this WebApplication app)
    {
        app.MapGet("/v1/filme", FilmeEndpoints.GetFilme);
        app.MapGet("/v1/filme/{idfilme:int}", FilmeEndpoints.GetFilmeById);
        app.MapPost("/v1/filme", FilmeEndpoints.PostFilme);
    }
}