using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.Api.Extensions.Contexts.PlanetContext;

public static class PlanetExtension
{
    public static void AddPlanetContext(this WebApplicationBuilder builder)
    {
        #region Register Planet Repository
        builder.Services.AddTransient
            <Core.Interfaces.Repositories.IPlanetRepository, 
            Infra.Repositories.PlanetRepository>();
        #endregion
    }

    public static void MapPlanetEndpoints(this WebApplication app)
    {
        #region Get all planets
        app.MapGet("api/v1/planets", async
            (IRequestHandler<Core.Contexts.PlanetContext.UseCases.SearchAll.Request,
            Core.Contexts.PlanetContext.UseCases.SearchAll.Response> handler) =>
        {
            var request = new Core.Contexts.PlanetContext.UseCases.SearchAll.Request();
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        })
            .WithTags("Planet")
            .Produces(TypedResults.Ok().StatusCode)
            .Produces(TypedResults.NotFound().StatusCode)
            .WithSummary("Return a list of planets")
            .WithOpenApi(); 
        #endregion

        #region Create planet
        app.MapPost("api/v1/planets/create", async (
            [FromBody] Core.Contexts.PlanetContext.UseCases.Create.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.PlanetContext.UseCases.Create.Request,
                Core.Contexts.PlanetContext.UseCases.Create.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Created($"api/v1/planets/create/{result.Data?.planet.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        })
            .WithTags("Planet")
            .Produces(TypedResults.Created().StatusCode)
            .Produces(TypedResults.BadRequest().StatusCode)
            .WithOpenApi()
            .WithSummary("Create a planet"); 
        #endregion
    }
}
