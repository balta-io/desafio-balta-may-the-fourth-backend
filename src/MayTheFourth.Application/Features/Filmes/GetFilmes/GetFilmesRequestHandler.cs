using MediatR;

namespace MayTheFourth.Application.Features.Filmes.GetFilmes
{
    public class GetFilmesRequestHandler : IRequestHandler<GetFilmesRequest>
    {
        public async Task<Unit> Handle(GetFilmesRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine("FUNCIONOU");

            return Unit.Value;
        }
    }
}
