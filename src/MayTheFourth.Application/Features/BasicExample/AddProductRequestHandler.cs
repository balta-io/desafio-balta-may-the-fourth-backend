using MediatR;

namespace MayTheFourth.Application.Features.BasicExample
{
    public class AddProductRequestHandler : IRequestHandler<AddProductRequest>
    {
        public async Task<Unit> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine("FUNCIONOU");

            return Unit.Value;
        }
    }
}
