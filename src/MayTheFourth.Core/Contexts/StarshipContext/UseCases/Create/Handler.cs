using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;

namespace MayTheFourth.Core.Contexts.StarshipContext.UseCases.Create;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IStarshipRepository _starshipRepository;

    public Handler(IStarshipRepository starshipRepository)
    {
        _starshipRepository = starshipRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validation
        // Need to implement a validation system
        #endregion

        #region Check if starship already exists
        try
        {
            var exists = await _starshipRepository.AnyAsync(request.Name, cancellationToken);
            if (exists)
                return new Response("O nome utilizado para a nave já foi utilizado.", 400);
        }
        catch (Exception ex)
        {
            return new Response($"Falha na verificação de existência da nave. Erro: {ex.Message}", 500);
        }
        #endregion

        #region Create starship
        Starship? starship;
        try
        {
            starship = CreateStarship(request);
            await _starshipRepository.SaveAsync(starship, cancellationToken);
        }
        catch (Exception ex)
        {
            return new Response($"Falha ao criar nave. Erro: {ex.Message}", 500);
        }
        #endregion

        #region Response
        return new Response("Nave criada com sucesso", new ResponseData(starship));
        #endregion
    }

    private Starship CreateStarship(Request request)
    {
        var starship = new Starship
        {
            Name = request.Name,
            Model = request.Model,
            StarshipClass = request.StarshipClass,
            Manufacturer = request.Manufacturer,
            CostInCredits = request.CostInCredits,
            Length = request.Length,
            Crew = request.Crew,
            Passagers = request.Passagers,
            MaxAtmospheringSpeed = request.MaxAtmospheringSpeed,
            HyperdriveRating = request.HyperdriveRating,
            MGLT = request.MGLT,
            CargoCapacity = request.CargoCapacity,
            Consumables = request.Consumables,
            Url = request.Url,
            Created = request.Created,
            Edited = request.Edited,
        };

        return starship;
    }
}
