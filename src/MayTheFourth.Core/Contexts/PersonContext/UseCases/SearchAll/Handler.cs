using MayTheFourth.Core.Contexts.SharedContext;
using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;
using System.Net;

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
        PagedList<Person>? people;

 
        int countItems = 0;
        try
        {
            if (request.PageSize > 30)
                request.ChangePageSize(30);

            countItems = await _personRepository.CountItemsAsync();
            people = await _personRepository.GetAllAsync(request.PageNumber, request.PageSize);
            if (request.PageSize > people.Count)
                people.ChangePageSize(countItems);
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", (int) HttpStatusCode.InternalServerError);
        }

        List<PersonSummaryDto> peopleSummaryList = people.Items!.Select(person => new PersonSummaryDto(person)).ToList();

        PagedList<PersonSummaryDto> peoplePagedSummaryList =
            new PagedList<PersonSummaryDto>(people.PageNumber, people.PageSize, countItems, peopleSummaryList);

        if (peoplePagedSummaryList.PageNumber > Math.Ceiling((double)peoplePagedSummaryList.Count / peoplePagedSummaryList.PageSize))
        {
            return new Response($"Número de página inválido.", (int)HttpStatusCode.BadRequest);
        }
        #endregion

        #region Response
        return new Response("Lista de personagens encontrada", new ResponseData(peoplePagedSummaryList));
        #endregion

    }
}

