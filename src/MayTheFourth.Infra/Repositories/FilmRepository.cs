using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Infra.Repositories
{
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

    }
}
