using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;
using System.Net;

namespace MayTheFourth.Core.Contexts.PlanetContext.UseCases.Delete;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IPlanetRepository _planetRepository;
    public Handler(IPlanetRepository planetRepository)
    {
        _planetRepository = planetRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validate Request
        //Implement validation system
        #endregion

        #region Remove planet by id  
        try
        {
            var response = await _planetRepository.DeletePlanetByIdAsync(request.Id, cancellationToken);
            if (response == false)
                return new Response("Erro: Planeta não encontrado.", ((int)HttpStatusCode.NotFound));
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", ((int)HttpStatusCode.InternalServerError));
        }
        #endregion

        #region Response
        return new Response($"Planeta {request.Id} removido com sucesso.", new ResponseData());
        #endregion
    }
}
