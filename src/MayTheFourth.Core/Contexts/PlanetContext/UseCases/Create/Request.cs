using MayTheFourth.Core.Entities;
using MediatR;

namespace MayTheFourth.Core.Contexts.PlanetContext.UseCases.Create;

public record Request(
    string Name, 
    string Diameter, 
    string RotationPeriod, 
    string OrbitalPeriod,
    string Gravity,
    string Population,
    string Climate,
    string Terrain,
    string SurfaceWater,
    string Url,
    DateTime Created,
    DateTime Edited,
    List<Person> Residents,
    List<Film> Films
    ) : IRequest<Response>;
