using Microsoft.EntityFrameworkCore;
using Staris.Domain.Common;
using System.Linq.Expressions;

namespace Staris.Domain.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();

	Task<TEntity?> GetByIdAsync(object[] keyValues);

	Task<PagedResult<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate, int actualPage = 1, int pageSize = 10);

	TEntity Create(TEntity entity);

	TEntity Update(TEntity entity);

	bool Delete(object[] keyValues);
}
