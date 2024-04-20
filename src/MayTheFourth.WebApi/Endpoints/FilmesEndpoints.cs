using Mapster;
using MayTheFourth.Application.Features.Filmes;
using MayTheFourth.Application.Features.Filmes.AddFilmes;
using MayTheFourth.Application.Features.Filmes.DeleteFilmes;
using MayTheFourth.Application.Features.Filmes.GetFilmes;
using MayTheFourth.Application.Features.Filmes.UpdateFilmes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MayTheFourth.WebApi.Endpoints
{
    public static class FilmesEndpoints
    {
        public static void MapFilmesEndpoints(this WebApplication app)
        {
            var root = app.MapGroup("/api/filmes")
               .WithTags("Filmes")
               .WithOpenApi();

            root.MapPost("/", AddFilmesAsync)
                .WithSummary("Cria um novo registro de filme")
                .WithDescription("Endpoint referente a criação de um novo registro de filme")
                .Produces(StatusCodes.Status201Created);

            root.MapGet("/", GetFilmesAsync)
                .WithSummary("Obtem todos os filmes cadastrados")
                .WithDescription("Endpoint para leitura e retorno da lista de filmes cadastrados");

            root.MapPut("/", UpdateFilmesAsync)
                .WithSummary("Atualiza o cadastro do filme")
                .WithDescription("Endpoint referente a atualização do cadastro do filme")
                .Produces(StatusCodes.Status204NoContent);

            root.MapDelete("/{id}", DeleteFilmesAsync)
                .WithSummary("Deleta o cadastro do filme")
                .WithDescription("Enpoint para deleção do cadastro do filme de acordo com o Id")
                .Produces(StatusCodes.Status204NoContent);
        }

        private static async Task<IResult> AddFilmesAsync
        (
            AddFilmesRequest request,
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken = default
        )
        {
            await mediator.Send(request, cancellationToken);

            return Results.Created();
        }

        private static async Task<IResult> GetFilmesAsync
        (
            [FromServices] IMediator mediator,
            CancellationToken cancellationToken
        )
        {
            var result = await mediator.Send(new GetFilmesRequest(), cancellationToken);

            return Results.Ok(result);
        }

        private static async Task<IResult> UpdateFilmesAsync
        (
           [FromBody] FilmesRequestBase request,
           [FromServices] IMediator mediator,
           CancellationToken cancellationToken = default
        )
        {
            var filme = request.Adapt<UpdateFilmesRequest>();

            await mediator.Send(filme, cancellationToken);

            return Results.NoContent();
        }

        private static async Task<IResult> DeleteFilmesAsync
        (
           [FromServices] IMediator mediator,
           int filmeId
        )
        {
            await mediator.Send(new DeleteFilmesRequest(filmeId));

            return Results.NoContent();
        }
    }
}
