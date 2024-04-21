using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;

namespace MayTheFourth.Tests.Repositories;

public class FakePlanetRepository : IPlanetRepository
{
    public List<Planet> planets = new()
    {
        new() { Name = "Alderaan", Gravity = 9.81 },
        new() { Name = "Tatooine", Gravity = 9.81 },
        new() { Name = "Naboo", Gravity = 9.81 },
        new() { Name = "Coruscant", Gravity = 9.81 },
        new() { Name = "Hoth", Gravity = 9.81 }
    };

    public Task<bool> AnyAsync(string name, double gravity)
    {
        if (string.Equals(name, planets[0].Name) && gravity.Equals(planets[0].Gravity))
            return Task.FromResult(true);

        return Task.FromResult(false);
    }

    public async Task<List<Planet>?> GetAllPlanets()
    {
        await Task.Delay(1000);
        return planets;
    }

    public Task SaveAsync(Planet planet, CancellationToken cancellationToken)
    {
        if (planet is null)
            return Task.FromResult(false);

        return Task.FromResult(true);
    }
}
