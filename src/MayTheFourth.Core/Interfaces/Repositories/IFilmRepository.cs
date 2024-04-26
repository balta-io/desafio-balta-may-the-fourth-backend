using MayTheFourth.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Core.Interfaces.Repositories
{
    public interface IFilmRepository
    {
        Task <(List<Film> films, int totalRecords)> GetAllAsync(int pageNumber, int pageSize);
        Task<Film?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
