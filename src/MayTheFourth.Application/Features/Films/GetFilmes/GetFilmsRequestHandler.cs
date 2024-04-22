using MediatR;

namespace MayTheFourth.Application.Features.Films.GetFilmes
{
    public class GetFilmsRequestHandler : IRequestHandler<GetFilmsRequest, List<GetFilmsResponse>>
    {
        public async Task<List<GetFilmsResponse>> Handle(GetFilmsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine("FUNCIONOU");

            return Unit.Value;
        }
    }
}
