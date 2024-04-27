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
            Core.Contexts.PersonContext.UseCases.SearchAll.Response> handler,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10) =>
        {
            var request = new Core.Contexts.PersonContext.UseCases.SearchAll.Request(pageNumber, pageSize);
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        })
            .WithTags("Person")
            .Produces(TypedResults.Ok().StatusCode)
            .Produces(TypedResults.NotFound().StatusCode)
            .WithSummary("Return a list of people")
            .WithOpenApi();
        #endregion

        #region Get person by id
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
        })
            .WithTags("Person")
            .WithSummary("Return a person according to ID")
            .WithOpenApi(opt =>
            {
                var parameter = opt.Parameters[0];
                parameter.Description = "The ID associated with the created Person";
                return opt;
            });
        #endregion

        #region Get person by slug
        app.MapGet("api/v1/people/slug/{slug}", async (
            [FromRoute] string slug,
            [FromServices] IRequestHandler<
                Core.Contexts.PersonContext.UseCases.SearchBySlug.Request,
                Core.Contexts.PersonContext.UseCases.SearchBySlug.Response> handler) =>
        {
            var request = new Core.Contexts.PersonContext.UseCases.SearchBySlug.Request(slug);
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        })
            .WithTags("Person")
            .WithSummary("Return a person according to slug")
            .WithOpenApi();
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
        })
            .WithTags("Person")
            .Produces(TypedResults.Created().StatusCode)
            .Produces(TypedResults.BadRequest().StatusCode)
            .WithOpenApi()
            .WithSummary("Create a person");
        #endregion
    }
}
