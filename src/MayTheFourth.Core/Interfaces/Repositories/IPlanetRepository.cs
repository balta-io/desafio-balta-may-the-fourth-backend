using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Interfaces.Repositories;

public interface IPlanetRepository
{
    Task<bool> AnyAsync(string name, string gravity);
    Task<List<Planet>?> GetAllAsync();
    Task<Planet?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task SaveAsync(Planet planet, CancellationToken cancellationToken);
}
