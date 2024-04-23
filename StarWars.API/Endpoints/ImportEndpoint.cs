namespace StarWars.API.Endpoints
{
    public static class ImportEndpoint
	{
        public static RouteGroupBuilder ImportEndpoints(
            this RouteGroupBuilder route, string routePrefix)
        {
            route.MapPost($"{routePrefix}/fromswapi", async () =>
            {
                // Todo: Implementação da logica do service que vai importar os dados

                // Todo: Remover após implementar o service
                await Task.Delay(0);

                return Results.NotFound();

            }).WithName($"ImportFromSwapiAsync{routePrefix}")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound);


            return route;
        }
    }
}

