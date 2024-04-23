using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.Api.Extensions.Contexts.StartshipContext;

public static class StarshipExtension
{
    public static void AddStarshipContext(this WebApplicationBuilder builder)
    {
        #region Register Starship Repository
        builder.Services.AddTransient<
            Core.Interfaces.Repositories.IStarshipRepository,
            Infra.Repositories.StarshipRepository>();
        #endregion
    }

    public static void MapStarshipEndpoints(this WebApplication app)
    {
        #region Get all starships
        app.MapGet("api/v1/starships", async (IRequestHandler<
            Core.Contexts.StarshipContext.UseCases.SearchAll.Request,
            Core.Contexts.StarshipContext.UseCases.SearchAll.Response> handler) =>
        {
            var request = new Core.Contexts.StarshipContext.UseCases.SearchAll.Request();
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region Create Starship
        app.MapPost("api/v1/starships/create", async (
            [FromBody] Core.Contexts.StarshipContext.UseCases.Create.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.StarshipContext.UseCases.Create.Request,
                Core.Contexts.StarshipContext.UseCases.Create.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Created($"api/v1/starships/create/{result.Data?.starship.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
