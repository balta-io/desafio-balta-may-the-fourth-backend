using MayTheFourth.Core.Contexts.SharedContext;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Infra.Repositories;

public class FilmRepository : BaseRepository<Film>, IFilmRepository
{
    public FilmRepository(AppDbContext appDbContext) 
        : base(appDbContext)
    {

    }

    public async Task<int> CountItemsAsync()
        => await _appDbContext.Films.CountAsync();

    public async Task<PagedList<Film>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _appDbContext.Films.AsQueryable();
        return await GetPagedAsync(query, pageNumber, pageSize);
    }

    public async Task<Film?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _appDbContext.Films
        .Include(x => x.SpeciesList)
        .Include(x => x.Starships)
        .Include(x => x.Vehicles)
        .Include(x => x.Characters)
        .Include(x => x.Planets)
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<Film?> GetBySlugAsync(string slug, CancellationToken cancellationToken)
        => await _appDbContext.Films
        .Include(x => x.SpeciesList)
        .Include(x  => x.Starships)
        .Include(x => x.Vehicles)
        .Include(x => x.Characters)
        .Include(x => x.Planets)
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Slug == slug, cancellationToken);
}
