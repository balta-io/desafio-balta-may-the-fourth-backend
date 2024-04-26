using Microsoft.AspNetCore.Mvc;
using StarWars.API.Services;

namespace StarWars.API.Endpoints
{
    public static class ImportEndpoint
    {
        public static RouteGroupBuilder ImportEndpoints(
            this RouteGroupBuilder route, string routePrefix)
        {
            route.MapPost($"{routePrefix}/fromswapi", async (
                [FromServices] IImportService importService,
                CancellationToken cancellationToken) =>
            {
                var response = await importService.FromSwapiAsync(cancellationToken);

                if (response)
                {
                    return Results.Ok(
                        new { message = "Importação de dados concluida com sucesso." });
                }

                return Results.BadRequest(
                    new { message = "Não foi possivel concluir a importação." });

            }).WithName($"ImportFromSwapiAsync{routePrefix}")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status400BadRequest);


            return route;
        }
    }
    
}

