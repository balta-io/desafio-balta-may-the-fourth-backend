using MayTheFourth.Core.Entities;
using MediatR;

namespace MayTheFourth.Core.Contexts.PersonContext.UseCases.Create;

public record Request(
    string Name,
    int Height,
    string Mass,
    string HairColor,
    string SkinColor,
    string EyeColor,
    string BirthYear,
    string Gender,
    Planet Homeworld,
    List<Film> Films,
    List<Species> Species,
    List<Vehicle> Vehicles,
    List<Starship> Starships,
    DateTime Created,
    DateTime Edited,
    string Url) : IRequest<Response>;
