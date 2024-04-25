using MayTheFourth.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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
        })
            .WithTags("Starship")
            .Produces(TypedResults.Ok().StatusCode)
            .Produces(TypedResults.NotFound().StatusCode)
            .WithSummary("Return a list of starships")
            .WithOpenApi();
        #endregion

        #region Search starship by id
        app.MapGet("api/v1/starships/{id}", async (
            [FromRoute] Guid id,
            [FromServices] IRequestHandler<
                Core.Contexts.StarshipContext.UseCases.SearchById.Request,
                Core.Contexts.StarshipContext.UseCases.SearchById.Response> handler) =>
        {
            var request = new Core.Contexts.StarshipContext.UseCases.SearchById.Request(id);
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        })
            .WithTags("Starship")
            .WithSummary("Return a starship according to ID")
            .WithOpenApi( opt =>
            {
                var parameter = opt.Parameters[0];
                parameter.Description = "The ID associated with the created Starship";
                return opt;
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
        })
            .WithTags("Starship")
            .Produces(TypedResults.Created().StatusCode)
            .Produces(TypedResults.BadRequest().StatusCode)
            .WithOpenApi()
            .WithSummary("Create a starship");
        #endregion
    }
}
