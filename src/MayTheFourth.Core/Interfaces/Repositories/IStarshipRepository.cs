using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Interfaces.Repositories;

public interface IStarshipRepository
{
    Task<bool> AnyAsync(string name, CancellationToken cancellationToken);
    Task<List<Starship>?> GetAllAsync();
    Task SaveAsync(Starship starship, CancellationToken cancellationToken);
    Task<Starship?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
