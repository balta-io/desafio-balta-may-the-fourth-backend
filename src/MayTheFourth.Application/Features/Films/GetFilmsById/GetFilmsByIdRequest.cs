using MediatR;

namespace MayTheFourth.Application.Features.Films.GetFilmsById
{
    public sealed record GetFilmsByIdRequest(int Id) : IRequest<GetFilmsResponse?>;
}
