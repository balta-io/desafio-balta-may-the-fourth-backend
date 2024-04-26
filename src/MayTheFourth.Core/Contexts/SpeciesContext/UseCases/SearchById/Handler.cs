using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;
using System.Net;

namespace MayTheFourth.Core.Contexts.SpeciesContext.UseCases.SearchById;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly ISpeciesRepository _speciesRepository;
    public Handler(ISpeciesRepository speciesRepository)
    {
        _speciesRepository = speciesRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validation
        //Need to implement a validation system
        #endregion

        #region Search species by id
        Species? species;
        try
        {
            species = await _speciesRepository.GetByIdAsync(request.Id, cancellationToken);
            if (species == null)
                return new Response("Espécie não encontrado.", ((int)HttpStatusCode.NotFound));
        }
        catch(Exception ex)
        {
            return new Response($"Erro: {ex.Message}", ((int)HttpStatusCode.InternalServerError));
        }

        SpeciesDetailsDto speciesDetails = new(species);
        #endregion

        #region Response
        return new Response("Espécie encontrada com sucesso.", new ResponseData(speciesDetails));
        #endregion
    }
}
