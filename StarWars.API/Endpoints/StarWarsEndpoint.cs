using System;
namespace StarWars.API.Endpoints
{
    public static class StarWarsEndpoint
    {
        public static RouteGroupBuilder StarWarsEndpoints(this RouteGroupBuilder route, string routePrefix)
        {
            route.MapGet($"{routePrefix}/getmoves", async () =>
            {
                // Todo: Implementação da logica do service que vai
                // retornar a lista de filmes

                // Todo: Remover após implementar o service
                await Task.Delay(0);

                return Results.NotFound();

            }).WithName($"GetMovesAsync{routePrefix}")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound);


            return route;
        }
    }
}

