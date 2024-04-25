using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Infra.Repositories;

public class PlanetRepository : IPlanetRepository
{
    private readonly AppDbContext _appDbContext;

    public PlanetRepository(AppDbContext appDbContext)
        => _appDbContext = appDbContext;

    public async Task<List<Planet>?> GetAllAsync()
        => await _appDbContext.Planets
            .AsNoTracking()
            .ToListAsync();

    public async Task<bool> AnyAsync(string name, string gravity)
        => await _appDbContext.Planets.AnyAsync(x => x.Name == name && x.Gravity.Equals(gravity));

    public async Task SaveAsync(Planet planet, CancellationToken cancellationToken)
    {
        await _appDbContext.Planets.AddAsync(planet);
        await _appDbContext.SaveChangesAsync();
    }
}
