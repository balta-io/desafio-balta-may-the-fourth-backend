using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Interfaces.Repositories;

public interface IPlanetRepository
{
    Task<List<Planet>?> GetAllPlanets();
}
