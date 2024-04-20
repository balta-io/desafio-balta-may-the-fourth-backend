using MediatR;

namespace MayTheFourth.Application.Features.Filmes.AddFilmes
{
    public class AddFilmesRequestHandler : IRequestHandler<AddFilmesRequest, Guid>
    {
        public async Task<Guid> Handle(AddFilmesRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine("FUNCIONOU");

            return Guid.NewGuid();
        }
    }
}
