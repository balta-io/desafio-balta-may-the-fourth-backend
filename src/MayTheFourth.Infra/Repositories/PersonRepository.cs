using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Infra.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _appDbContext;

    public PersonRepository(AppDbContext appDbContext)
        => _appDbContext = appDbContext;

    public async Task<List<Person>?> GetAllAsync()
        => await _appDbContext
                .People
                .AsNoTracking()
                .ToListAsync();

    public async Task<bool> AnyAsync(string name, string birthYear)
       => await _appDbContext.People.AnyAsync(x => x.Name == name && x.BirthYear.Equals(birthYear));

    public async Task SaveAsync(Person person, CancellationToken cancellationToken)
    {
        await _appDbContext.People.AddAsync(person);
        await _appDbContext.SaveChangesAsync();
    }
}
