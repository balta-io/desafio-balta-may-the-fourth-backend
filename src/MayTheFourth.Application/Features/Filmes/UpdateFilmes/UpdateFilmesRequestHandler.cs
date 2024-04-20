using MayTheFourth.Application.Features.Filmes.UpdateFilmes;
using MediatR;

namespace MayTheFourth.Application.Features.BasicExample
{
    public class UpdateFilmesRequestHandler : IRequestHandler<UpdateFilmesRequest>
    {
        public async Task<Unit> Handle(UpdateFilmesRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine("FUNCIONOU");

            return Unit.Value;
        }
    }
}
