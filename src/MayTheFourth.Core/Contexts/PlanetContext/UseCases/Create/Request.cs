using MayTheFourth.Core.Entities;
using MediatR;

namespace MayTheFourth.Core.Contexts.PlanetContext.UseCases.Create;

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
