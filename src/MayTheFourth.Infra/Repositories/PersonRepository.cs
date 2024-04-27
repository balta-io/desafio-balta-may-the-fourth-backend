using MayTheFourth.Core.Contexts.SharedContext;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Infra.Repositories;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(AppDbContext appDbContext) : base(appDbContext) { }

    public async Task<PagedList<Person>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _appDbContext.People.AsQueryable();
        return await GetPagedAsync(query, pageNumber, pageSize);
    }

    public async Task<int> CountItemsAsync()
    => await _appDbContext.People.CountAsync();

    public async Task<bool> AnyAsync(string name, string birthYear)
       => await _appDbContext.People.AnyAsync(x => x.Name == name && x.BirthYear.Equals(birthYear));

    public async Task SaveAsync(Person person, CancellationToken cancellationToken)
    {
        await _appDbContext.People.AddAsync(person);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Person?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _appDbContext.People
        .Include(x => x.Films)
        .Include(x => x.Species)
        .Include(x => x.Starships)
        .Include(x => x.Vehicles)
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<Person?> GetBySlugAsync(string slug, CancellationToken cancellationToken)
        => await _appDbContext.People
        .Include(x => x.Films)
        .Include(x => x.Species)
        .Include(x => x.Starships)
        .Include(x => x.Vehicles)
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Slug == slug, cancellationToken);
}
