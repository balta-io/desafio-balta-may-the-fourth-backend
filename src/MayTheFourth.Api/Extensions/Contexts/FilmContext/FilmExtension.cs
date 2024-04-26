using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.Api.Extensions.Contexts.FilmContext
{
    public static class FilmExtension
    {
        public static void AddFilmContext(this WebApplicationBuilder builder)
        {
            #region Register Film Repository
            builder.Services.AddTransient
                <Core.Interfaces.Repositories.IFilmRepository,
                Infra.Repositories.FilmRepository>();
            #endregion
        }

        public static void MapFilmEndpoints(this WebApplication app)
        {
            #region Get all films
            app.MapGet("api/v1/films", async
                (
                IRequestHandler<Core.Contexts.FilmContext.UseCases.SearchAll.Request,
                Core.Contexts.FilmContext.UseCases.SearchAll.Response> handler,
                [FromQuery] int pageNumber = 1,
                [FromQuery] int pageSize = 10) =>
            {
                var request = new Core.Contexts.FilmContext.UseCases.SearchAll.Request(pageNumber, pageSize);
                var result = await handler.Handle(request, new CancellationToken());

                return result.IsSuccess
                    ? Results.Ok(result)
                    : Results.Json(result, statusCode: result.Status);
            })
                .WithTags("Film")
                .Produces(TypedResults.Ok().StatusCode)
                .Produces(TypedResults.NotFound().StatusCode)
                .WithSummary("Return a list of films")
                .WithOpenApi();
            #endregion

            #region Get film by id
            app.MapGet("api/v1/films/{id}", async (
                [FromRoute] Guid id,
                [FromServices] IRequestHandler<
                    Core.Contexts.FilmContext.UseCases.SearchById.Request,
                    Core.Contexts.FilmContext.UseCases.SearchById.Response> handler) =>
            {
                var request = new Core.Contexts.FilmContext.UseCases.SearchById.Request(id);
                var result = await handler.Handle(request, new CancellationToken());

                return result.IsSuccess
                    ? Results.Ok(result)
                    : Results.Json(result, statusCode: result.Status);
            })
                .WithTags("Film")
                .WithSummary("Return a film according to ID")
                .WithOpenApi(opt =>
                {
                    var parameter = opt.Parameters[0];
                    parameter.Description = "The ID associated with the created Film";
                    return opt;
                });
            #endregion

            #region Get film by slug
            app.MapGet("api/v1/films/slug/{slug}", async (
                [FromRoute] string slug,
                [FromServices] IRequestHandler<
                    Core.Contexts.FilmContext.UseCases.SearchBySlug.Request,
                    Core.Contexts.FilmContext.UseCases.SearchBySlug.Response> handler) =>
            {
                var request = new Core.Contexts.FilmContext.UseCases.SearchBySlug.Request(slug);
                var result = await handler.Handle(request, new CancellationToken());

                return result.IsSuccess
                    ? Results.Ok(result)
                    : Results.Json(result, statusCode: result.Status);
            });
            #endregion
        }

    }
}
