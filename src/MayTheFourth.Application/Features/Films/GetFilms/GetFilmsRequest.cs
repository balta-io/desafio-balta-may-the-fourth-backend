using MediatR;

namespace MayTheFourth.Application.Features.Films.GetFilmes
{
    public sealed record GetFilmsRequest : IRequest<List<GetFilmsResponse>>;
}
