using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;

namespace MayTheFourth.Core.Contexts.PlanetContext.UseCases.Create;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IPlanetRepository _planetRepository;
    public Handler(IPlanetRepository planetRepository)
    {
        _planetRepository = planetRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validation
        // Need to implement a validation system
        #endregion

        #region Check if planet already exists
        try
        {
            var exists = await _planetRepository.AnyAsync(request.Name, request.Gravity);
            if (exists)
                return new Response("Erro: Planeja já cadastrado.", 400);
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", 500);
        }
        #endregion

        #region Create a new planet
        Planet? planet;
        try
        {
            planet = new Planet();
            await _planetRepository.SaveAsync(planet, cancellationToken);
        }
        catch(Exception ex)
        {
            return new Response($"Erro: {ex.Message}", 500);
        }
        #endregion

        #region Response
        return new Response("Planeta cadastrado com sucesso.", new ResponseData(planet));
        #endregion
    }
}
