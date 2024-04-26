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
        Task<List<Species>?> GetAllAsync();
        Task<Species?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
