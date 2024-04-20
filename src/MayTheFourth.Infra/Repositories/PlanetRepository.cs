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

    public async Task<List<Planet>?> GetAllPlanets()
        => await _appDbContext.Planets.AsNoTracking().ToListAsync();
}
