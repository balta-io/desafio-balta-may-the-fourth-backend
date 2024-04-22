using MayTheFourth.Application.Common.AppServices;
using MediatR;

namespace MayTheFourth.Application.Features.Filmes.AddFilmes
{
    public class AddFilmesRequestHandler : IRequestHandler<AddFilmesRequest, Guid>
    {
        private readonly IPopulateSWDataBaseAppService _populateSWDataBaseAppService;

        public AddFilmesRequestHandler(IPopulateSWDataBaseAppService populateSWDataBaseAppService)
        {
            _populateSWDataBaseAppService = populateSWDataBaseAppService;
        }

        public async Task<Guid> Handle(AddFilmesRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _populateSWDataBaseAppService.PopulateSWDataBase(cancellationToken);

            Console.WriteLine("FUNCIONOU");

            return Guid.NewGuid();
        }
    }
}
