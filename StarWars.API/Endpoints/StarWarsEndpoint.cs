using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StarWars.API.Services;

namespace StarWars.API.Endpoints
{
    public static class StarWarsEndpoint
    {
        public static RouteGroupBuilder StarWarsEndpoints(
            this RouteGroupBuilder route, string routePrefix)
        {
            route.MapGet($"{routePrefix}/getmovies", async (
               [FromServices] IStarWarsService starWarsService,
                CancellationToken cancellationToken) =>
            {
                var _movies = await starWarsService.GetMoviesAsync(
                    cancellationToken);

                if (_movies is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(_movies);

            }).WithName($"GetMoviesAsync{routePrefix}")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound);

            route.MapGet($"{routePrefix}/getcharacters", async (
               [FromServices] IStarWarsService starWarsService,
                CancellationToken cancellationToken) =>
            {
                var _characters = await starWarsService.GetCharacterAsync(
                    cancellationToken);

                if (_characters is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(_characters);

            }).WithName($"GetCharactersAsync{routePrefix}")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound);

            route.MapGet($"{routePrefix}/getvehicles", async (
                    [FromServices] IStarWarsService starWarsService,
                    CancellationToken CancellationToken) =>
                {
                    var _vehicles = await starWarsService.GetVehicleAsync(
                        CancellationToken);
                    if (_vehicles is null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(_vehicles);
                })
                .WithName($"GetVehiclesAsync{routePrefix}")
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);
            return route;
            
            
            


        }
    }
}

