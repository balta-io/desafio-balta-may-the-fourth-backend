using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;
using System.Net;

namespace MayTheFourth.Core.Contexts.PersonContext.UseCases.SearchBySlug;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IPersonRepository _personRepository;
    public Handler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validate Request
        //TODO: Implement validation system
        #endregion

        #region Get character(person) by slug
        Person? person;
        try
        {
            person = await _personRepository.GetBySlugAsync(request.Slug, cancellationToken);
            if (person == null)
                return new Response("Erro: Personagem não encontrado.", ((int)HttpStatusCode.NotFound));
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", ((int)HttpStatusCode.InternalServerError));
        }

        PersonDetailsDto personDetails = new(person);
        #endregion

        #region Response
        return new Response("Personagem encontrado com sucesso.", new ResponseData(personDetails));
        #endregion
    }
}
