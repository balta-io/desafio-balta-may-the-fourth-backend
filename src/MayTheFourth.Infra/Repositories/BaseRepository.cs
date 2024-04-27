using MayTheFourth.Core.Contexts.SharedContext;
using MayTheFourth.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Infra.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected readonly AppDbContext _appDbContext;

        protected BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        protected async Task<PagedList<T>> GetPagedAsync(IQueryable<T> query, int pageNumber, int pageSize)
        {
            var totalRecords = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            
            return new PagedList<T>(pageNumber, pageSize, totalRecords, items);
        }
    }

}
