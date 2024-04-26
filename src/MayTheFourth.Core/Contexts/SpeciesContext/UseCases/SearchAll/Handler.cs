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
        #region Get All Species
        List<Species>? speciesList;
        try
        {
            speciesList = await _speciesRepository.GetAllAsync();
            if (speciesList!.Count <= 0)
                return new Response("Nenhum espécie encontrada.", (int) HttpStatusCode.OK );
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", (int) HttpStatusCode.InternalServerError);
        }

        List<SpeciesSummaryDto> speciesSummaryList = speciesList.Select(species => new SpeciesSummaryDto(species)).ToList();
        #endregion

        #region Response
        return new Response("Lista de espécies encontrada.", new ResponseData(new(speciesSummaryList)));
        #endregion
    }
}
