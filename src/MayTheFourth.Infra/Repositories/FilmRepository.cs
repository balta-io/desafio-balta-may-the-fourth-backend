using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Infra.Repositories;

public class FilmRepository : IFilmRepository
{
    private readonly AppDbContext _appDbContext;

    public FilmRepository(AppDbContext appDbContext)
        =>  _appDbContext = appDbContext;

    public async Task<List<Film>> GetAllAsync()
        => await _appDbContext
                .Films
                .AsNoTracking()
                .ToListAsync();

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
