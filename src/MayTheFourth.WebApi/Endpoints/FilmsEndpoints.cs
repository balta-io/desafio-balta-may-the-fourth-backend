using MayTheFourth.Application.Features.Films.GetFilmes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.WebApi.Endpoints
{
    public static class FilmsEndpoints
    {
        public static void MapFilmsEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/filmes")
               .WithTags("Filmes")
               .WithOpenApi();

            root.MapGet("/", GetFilmesAsync)
                .WithSummary("Obtem todos os filmes cadastrados")
                .WithDescription("Endpoint para leitura e retorno da lista de filmes cadastrados");

            root.MapGet("/{id}", GetFilmesByIdAsync)
               .WithSummary("Obtem todos os filmes cadastrados")
               .WithDescription("Endpoint para leitura e retorno da lista de filmes cadastrados");
        }

        private static async Task<IResult> GetFilmesAsync
        (
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken
        )
        {
            var result = await mediator.Send(new GetFilmsRequest(), cancellationToken);

            return Results.Ok(result);
        }

        private static async Task<IResult> GetFilmesByIdAsync
        (
           [FromServices] IMediator mediator,
           CancellationToken cancellationToken = default
        )
        {
            var result = await mediator.Send(new GetFilmsRequest(), cancellationToken);

            return Results.Ok(result);
        }
    }
}
