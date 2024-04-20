using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;

namespace MayTheFourth.Core.Contexts.PlanetContext.UseCases.SearchAllPlanets;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IPlanetRepository _planetRepository;
    public Handler(IPlanetRepository planetRepository)
    {
        _planetRepository = planetRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Get All Planets
        List<Planet>? planets;
        try
        {
            planets = await _planetRepository.GetAllPlanets();
            if (planets is null)
                return new Response("Nenhum planeta encontrado.", 404);
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", 400);
        }
        #endregion

        #region Response
        return new Response("Uma lista de planetas foi encontrado.", new ResponseData(planets!));
        #endregion
    }
}
