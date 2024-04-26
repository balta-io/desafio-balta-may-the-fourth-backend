using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;
using System.Net;

namespace MayTheFourth.Core.Contexts.PlanetContext.UseCases.SearchBySlug;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IPlanetRepository _planetRepository;
    public Handler(IPlanetRepository planetRepository)
    {
        _planetRepository = planetRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Get Planet by slug
        Planet? planet;
        try
        {
            planet = await _planetRepository.GetBySlugAsync(request.Slug, cancellationToken);
            if (planet == null)
                return new Response("Planeta não encontrado.", ((int)HttpStatusCode.NotFound));
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", ((int)HttpStatusCode.InternalServerError));
        }

        PlanetDetailsDto planetDetails = new(planet);
        #endregion

        #region Response
        return new Response("Planeta encontrado com sucesso.", new ResponseData(planetDetails));
        #endregion
    }
}
