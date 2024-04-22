using MediatR;

namespace MayTheFourth.Application.Features.Films.GetFilmsById
{
    public class GetFilmsByIdRequestHandler : IRequestHandler<GetFilmsByIdRequest, GetFilmsResponse>
    {
        public async Task<GetFilmsResponse> Handle(GetFilmsByIdRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine("FUNCIONOU");

            return default;
        }
    }
}
