using MayTheFourth.Core.Entities;
using MediatR;
using System.Runtime.Serialization;

namespace MayTheFourth.Core.Contexts.FilmContext.UseCases.Create;

public record Request(
    string Name, 
    int Diameter, 
    int RotationPeriod, 
    int OrbitalPeriod,
    string Gravity,
    int Population,
    string Climate,
    string Terrain,
    string SurfaceWater,
    string Url,
    DateTime Created,
    DateTime Edited,
    List<Person> Residents,
    List<Film> Films
    ) : IRequest<Response>;
