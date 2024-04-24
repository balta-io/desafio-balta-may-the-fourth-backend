using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;

namespace MayTheFourth.Core.Contexts.PlanetContext.UseCases.SearchAll;

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
            planets = await _planetRepository.GetAllAsync();
            if (planets!.Count <= 0)
                return new Response("Nenhum planeta encontrado.", 404);
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", 500);
        }

        List<PlanetDetailsDto> planetDetailList = planets.Select(planet => new PlanetDetailsDto(planet)).ToList();
        #endregion

        #region Response
        return new Response("Uma lista de planetas foi encontrado.", new ResponseData(new(planetDetailList)));
        #endregion
    }
}
