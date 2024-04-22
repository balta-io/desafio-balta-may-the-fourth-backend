using MayTheFourth.Application.Features.Films;
using MayTheFourth.Application.Features.Films.GetFilmes;
using MayTheFourth.Application.Features.Films.GetFilmsById;
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
                .Produces<List<GetFilmsResponse>>()
                .WithSummary("Obtem todos os filmes cadastrados")
                .WithDescription("Endpoint para leitura e retorno da lista de filmes cadastrados");

            root.MapGet("/{id}", GetFilmesByIdAsync)
                .Produces<GetFilmsResponse>()
                .WithSummary("Obtem um filme cadastrado")
                .WithDescription("Endpoint para leitura e retorno de um filme cadastrado pelo Id correspondente");
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
           [FromRoute] int id,
           [FromServices] IMediator mediator
        )
        {
            var result = await mediator.Send(new GetFilmsByIdRequest(id));

            return Results.Ok(result);
        }
    }
}
