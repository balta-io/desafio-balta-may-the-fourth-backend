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

        #region Get planet by id
        app.MapGet("api/v1/planets/{id}", async (
            [FromRoute] Guid id,
            [FromServices] IRequestHandler<
                Core.Contexts.PlanetContext.UseCases.SearchById.Request,
                Core.Contexts.PlanetContext.UseCases.SearchById.Response> handler) =>
        {
            var request = new Core.Contexts.PlanetContext.UseCases.SearchById.Request(id);
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        })
            .WithTags("Planet")
            .WithSummary("Return a planet according to ID")
            .WithOpenApi(opt =>
            {
                var parameter = opt.Parameters[0];
                parameter.Description = "The ID associated with the created Planet";
                return opt;
            });
        #endregion

        #region Get planet by slug
        app.MapGet("api/v1/planets/slug/{slug}", async (
            [FromRoute] string slug,
            [FromServices] IRequestHandler<
                Core.Contexts.PlanetContext.UseCases.SearchBySlug.Request,
                Core.Contexts.PlanetContext.UseCases.SearchBySlug.Response> handler) =>
        {
            var request = new Core.Contexts.PlanetContext.UseCases.SearchBySlug.Request(slug);
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        });
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

        #region Remove planet
        app.MapDelete("api/v1/planets/{id}", async (
            [FromRoute] Guid id,
            [FromServices] IRequestHandler<
                Core.Contexts.PlanetContext.UseCases.Delete.Request,
                Core.Contexts.PlanetContext.UseCases.Delete.Response> handler) =>
        {
            var request = new Core.Contexts.PlanetContext.UseCases.Delete.Request(id);
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Accepted("", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
