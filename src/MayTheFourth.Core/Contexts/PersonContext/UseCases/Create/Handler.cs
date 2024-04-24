using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;

namespace MayTheFourth.Core.Contexts.PersonContext.UseCases.Create;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IPersonRepository _personRepository;
    public Handler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validation
        // Need to implement a validation system
        #endregion

        #region Check if person already exists
        try
        {
            var exists = await _personRepository.AnyAsync(request.Name, request.BirthYear);
            if (exists)
                return new Response("Erro: Personagem já cadastrado.", 400);
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", 500);
        }
        #endregion

        #region Create a new person
        Person? person;
        try
        {
            person = CreatePerson(request);
            await _personRepository.SaveAsync(person, cancellationToken);
        }
        catch(Exception ex)
        {
            return new Response($"Erro: {ex.Message}", 500);
        }
        #endregion

        #region Response
        return new Response("Personagem cadastrado com sucesso.", new ResponseData(person));
        #endregion
    }

    private Person CreatePerson(Request request)
    {
        var person = new Person
        {
            Name = request.Name,
            Height = request.Height,
            Mass = request.Mass,
            HairColor = request.HairColor,
            SkinColor = request.SkinColor,
            EyeColor = request.EyeColor,
            BirthYear = request.BirthYear,
            Gender = request.Gender,
            Homeworld = request.Homeworld,
            Films = request.Films,
            Species = request.Species,
            Vehicles = request.Vehicles,
            Starships = request.Starships,
            Created = request.Created,
            Edited = request.Edited,
            Url = request.Url            
        };

        return person;
    }
}
