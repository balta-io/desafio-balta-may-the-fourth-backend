using MayTheFourth.Core.Contexts.SharedContext;
using MayTheFourth.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Core.Interfaces.Repositories
{
    public interface ISpeciesRepository
    {
        Task<int> CountItemsAsync();
        Task<PagedList<Species>> GetAllAsync(int pageNumber, int pageSize);
        Task<Species?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
