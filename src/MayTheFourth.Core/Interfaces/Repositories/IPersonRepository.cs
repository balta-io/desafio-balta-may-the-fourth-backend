using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Interfaces.Repositories;

public interface IPersonRepository
{
    Task<bool> AnyAsync(string name, string birthYear);
    Task<List<Person>?> GetAllAsync();
    Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Person?> GetBySlugAsync(string slug, CancellationToken cancellationToken);
    Task SaveAsync(Person person, CancellationToken cancellationToken);
}
