using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;
using System.Net;

namespace MayTheFourth.Core.Contexts.StarshipContext.UseCases.SearchById;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IStarshipRepository _starshipRepository;

    public Handler(IStarshipRepository starshipRepository)
    {
        _starshipRepository = starshipRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validation Request
        //TODO: Need implement a validation system
        #endregion

        #region Search starship by id
        Starship? starship;
        try
        {
            starship = await _starshipRepository.GetByIdAsync(request.Id, cancellationToken);
            if (starship == null)
                return new Response("Erro: Nave não encontrada.", ((int)HttpStatusCode.NotFound));
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", ((int)HttpStatusCode.InternalServerError));
        }

        StarshipDetailsDto starshipDetails = new(starship);
        #endregion

        #region Response
        return new Response("Nave encontrada.", new ResponseData(starshipDetails));
        #endregion
    }
}
