using MediatR;

namespace MayTheFourth.Application.Features.Filmes.DeleteFilmes
{
    public class DeleteFilmesRequestHandler : IRequestHandler<DeleteFilmesRequest>
    {
        public async Task<Unit> Handle(DeleteFilmesRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine("FUNCIONOU");

            return Unit.Value;
        }
    }
}
