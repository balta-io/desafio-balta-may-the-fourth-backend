using MayTheFourth.Core.Contexts.SharedContext;
using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;
using System.Net;

namespace MayTheFourth.Core.Contexts.SpeciesContext.UseCases.SearchAll;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly ISpeciesRepository _speciesRepository;
    public Handler(ISpeciesRepository speciesRepository)
    {
        _speciesRepository = speciesRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region GetAllSpecies
        PagedList<Species>? speciesList;

        int countItems = 0;
        try
        {
            if (request.PageSize > 30)
                request.ChangePageSize(30);

            countItems = await _speciesRepository.CountItemsAsync();
            speciesList = await _speciesRepository.GetAllAsync(request.PageNumber, request.PageSize);
            if (request.PageSize > speciesList.Count)
                speciesList.ChangePageSize(countItems);
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", (int)HttpStatusCode.InternalServerError);
        }

        List<SpeciesSummaryDto> speciesSummaryList = speciesList.Items!.Select(species => new SpeciesSummaryDto(species)).ToList();

        PagedList<SpeciesSummaryDto> speciesPagedSummaryList =
            new PagedList<SpeciesSummaryDto>(speciesList.PageNumber, speciesList.PageSize, countItems, speciesSummaryList);

        if (speciesPagedSummaryList.PageNumber > Math.Ceiling((double)speciesPagedSummaryList.Count / speciesPagedSummaryList.PageSize))
        {
            return new Response($"Número de página inválido.", (int)HttpStatusCode.BadRequest);
        }
        #endregion

        #region Response
        return new Response("Lista de espécies encontrada", new ResponseData(speciesPagedSummaryList));
        #endregion
    }
}
