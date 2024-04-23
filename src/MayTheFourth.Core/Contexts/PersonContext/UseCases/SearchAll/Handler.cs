using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;

namespace MayTheFourth.Core.Contexts.PersonContext.UseCases.SearchAll;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IPersonRepository _personRepository;

    public Handler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region GetAllPeople
        List<Person>? people;

        try
        {
            people = await _personRepository.GetAllAsync();
            if (people!.Count <= 0)
                return new Response("Nenhum personagem encontrado.", 404);
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", 500);
        }
        #endregion

        #region Response
        return new Response("Lista de personagens encontrada", new ResponseData(people!));
        #endregion
    }
}

