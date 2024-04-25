using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;
using System.Net;

namespace MayTheFourth.Core.Contexts.PersonContext.UseCases.SearchById;

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
        //TODO: Need to add a validation system
        #endregion

        #region Get character by id
        Person? person;
        try
        {
            person = await _personRepository.GetByIdAsync(request.Id, cancellationToken);
            if (person == null)
                return new Response("Personagem não encontrado.", ((int)HttpStatusCode.NotFound));
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", ((int)HttpStatusCode.InternalServerError));
        }

        PersonDetailsDto personDetail = new(person);
        #endregion

        #region Response
        return new Response("Personagem encontrado.", new ResponseData(personDetail));
        #endregion
    }
}
