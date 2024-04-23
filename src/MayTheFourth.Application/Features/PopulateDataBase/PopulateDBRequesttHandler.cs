using MayTheFourth.Application.Common.AppServices;
using MediatR;

namespace MayTheFourth.Application.Features.PopulateDataBase
{
    public class PopulateDBRequesttHandler(IPopulateSWDataBaseAppService populateSWDataBaseAppService)
        : IRequestHandler<PopulateDBRequest>
    {
        private readonly IPopulateSWDataBaseAppService _populateSWDataBaseAppService = populateSWDataBaseAppService;

        public async Task<Unit> Handle(PopulateDBRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _populateSWDataBaseAppService.PopulateSWDataBase(cancellationToken);

            return Unit.Value;
        }
    }
}
