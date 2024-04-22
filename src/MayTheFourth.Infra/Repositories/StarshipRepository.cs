using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Infra.Repositories;

public class StarshipRepository : IStarshipRepository
{
    private readonly AppDbContext _appDbContext;

    public StarshipRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<Starship>?> GetAllAsync()
    => await _appDbContext.Starships.AsNoTracking().ToListAsync();

    public async Task<bool> AnyAsync(string name, CancellationToken cancellationToken)
        => await _appDbContext.Starships.AnyAsync(x => x.Name == name, cancellationToken);

    public async Task SaveAsync(Starship starship, CancellationToken cancellationToken)
    {
        await _appDbContext.Starships.AddAsync(starship);
        await _appDbContext.SaveChangesAsync();
    }
}
