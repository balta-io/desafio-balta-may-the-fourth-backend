using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.Api.Extensions.Contexts.PersonContext;

public static class PersonExtension
{
    public static void AddPersonContext(this WebApplicationBuilder builder)
    {
        #region Register Person Repository
        builder.Services.AddTransient
            <Core.Interfaces.Repositories.IPersonRepository,
            Infra.Repositories.PersonRepository>();
        #endregion
    }

    public static void MapPersonEndpoints(this WebApplication app)
    {
        #region Get all people
        app.MapGet("api/v1/people", async
            (IRequestHandler<Core.Contexts.PersonContext.UseCases.SearchAll.Request,
            Core.Contexts.PersonContext.UseCases.SearchAll.Response> handler) =>
        {
            var request = new Core.Contexts.PersonContext.UseCases.SearchAll.Request();
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region Search person by id
        app.MapGet("api/v1/people/{id}", async (
            [FromRoute] Guid id,
            [FromServices] IRequestHandler<
                Core.Contexts.PersonContext.UseCases.SearchById.Request,
                Core.Contexts.PersonContext.UseCases.SearchById.Response> handler) =>
        {
            var request = new Core.Contexts.PersonContext.UseCases.SearchById.Request(id);
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region Create person
        app.MapPost("api/v1/people/create", async (
            [FromBody] Core.Contexts.PersonContext.UseCases.Create.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.PersonContext.UseCases.Create.Request,
                Core.Contexts.PersonContext.UseCases.Create.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Created($"api/v1/people/create/{result.Data?.person.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
