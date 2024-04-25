using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;

namespace MayTheFourth.Tests.Repositories;

public class FakeStarshipRepository : IStarshipRepository
{
    public List<Starship> starships = new()
    {
        new(){
          Name = "Executor",
          Model = "Executor-class Star Dreadnought",
          StarshipClass = "Star Dreadnought",
          Manufacturer = "Kuat Drive Yards",
          CostInCredits = 1143350000,
          Length = 19000.0,
          Crew = 279,
          Passengers = 38000,
          MaxAtmospheringSpeed = 40,
          HyperdriveRating = "2.0",
          MGLT = "40",
          CargoCapacity = 25000000,
          Consumables = "6 years",
          Url = "https://starwars.fandom.com/wiki/Executor",
          Created = DateTime.UtcNow,
          Edited = DateTime.UtcNow
        },
        new(){
          Name = "Millennium Falcon",
          Model = "YT-1300 light freighter",
          StarshipClass = "Light freighter",
          Manufacturer = "Corellian Engineering Corporation",
          CostInCredits = 100000,
          Length = 34.37,
          Crew = 4,
          Passengers = 6,
          MaxAtmospheringSpeed = 1050,
          HyperdriveRating = "0.5",
          MGLT = "75",
          CargoCapacity = 100000,
          Consumables = "2 months",
          Url = "https://starwars.fandom.com/wiki/Millennium_Falcon",
          Created = DateTime.UtcNow,
          Edited = DateTime.UtcNow
}
    };

    public Task<bool> AnyAsync(string name, CancellationToken cancellationToken)
    {
        if (string.Equals(name, starships[0].Name))
            return Task.FromResult(true);

        return Task.FromResult(false);
    }

    public async Task<List<Starship>?> GetAllAsync()
    {
        await Task.Delay(1000);
        return starships;
    }

    public Task<Starship?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync(Starship starship, CancellationToken cancellationToken)
    {
        if (starship is null)
            return Task.FromResult(false);

        return Task.FromResult(true);
    }
}
