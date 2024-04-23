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

    public async Task<List<Person>> GetAllAsync()
        => await _appDbContext
                .People
                .Include(x => x.Species)
                .Include(x => x.Films)
                .Include(x => x.Starships)
                .Include(x => x.Vehicles)
                .AsNoTracking()
                .ToListAsync();
}
