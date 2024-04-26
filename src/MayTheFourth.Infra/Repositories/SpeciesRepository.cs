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
    public class SpeciesRepository : ISpeciesRepository
    {
        private readonly AppDbContext _appDbContext;

        public SpeciesRepository(AppDbContext appDbContext)
            => _appDbContext = appDbContext;

        public async Task<List<Species>?> GetAllAsync()
            => await _appDbContext
                    .Species
                    .AsNoTracking()
                    .ToListAsync();

        public async Task<Species?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => await _appDbContext.Species
            .Include(x => x.Films)
            .Include(x => x.People)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
