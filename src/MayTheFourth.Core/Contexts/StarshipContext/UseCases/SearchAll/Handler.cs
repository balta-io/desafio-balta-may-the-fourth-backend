using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;

namespace MayTheFourth.Core.Contexts.StarshipContext.UseCases.SearchAll;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IStarshipRepository _starshipRepository;

    public Handler(IStarshipRepository starshipRepository)
    {
        _starshipRepository = starshipRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Get List of Starships
        List<Starship>? starships;
        try
        {
            starships = await _starshipRepository.GetAllAsync();
            if (starships!.Count <= 0)
                return new Response("Nenhuma nave encontrada.", 404);

        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", 500);
        }

        List<StarshipDetailsDto> starshipDetailsList = starships.Select(starship => new StarshipDetailsDto(starship)).ToList();
        #endregion

        #region Response
        return new Response("Lista de naves encontrada.", new ResponseData(new(starshipDetailsList)));
        #endregion
    }
}
