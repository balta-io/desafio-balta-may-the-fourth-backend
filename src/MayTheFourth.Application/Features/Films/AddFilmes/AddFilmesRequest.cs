using MediatR;

namespace MayTheFourth.Application.Features.Filmes.AddFilmes
{
    public sealed record AddFilmesRequest : FilmesRequestBase, IRequest<Guid>;
}
