using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    .Include(x => x.Planets)
                    .Include(x => x.Characters)
                    .Include(x => x.Vehicles)
                    .Include(x => x.Starships)
                    .Include(x => x.SpeciesList)
                    .AsNoTracking()
                    .ToListAsync();

    }
}
