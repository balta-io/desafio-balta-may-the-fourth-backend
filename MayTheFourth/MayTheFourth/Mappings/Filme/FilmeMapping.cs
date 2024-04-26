using MayTheFourth.Endpoints.Filme;

namespace MayTheFourth.Mappings.Filme;

public static class FilmeMapping
{
    public static void FilmeMapEndpoints(this WebApplication app)
    {
        app.MapGet("/v1/filme", FilmeEndpoints.GetFilme);
        app.MapGet("/v1/filme/{idfilme:int}", FilmeEndpoints.GetFilmeById);
        app.MapPost("/v1/filme", FilmeEndpoints.PostFilme);
    }
}