using MediatR;

namespace MayTheFourth.Application.Features.Filmes.UpdateFilmes
{
    public sealed record UpdateFilmesRequest : FilmesRequestBase, IRequest;
}
