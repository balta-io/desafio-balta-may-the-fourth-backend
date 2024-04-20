using System.Linq.Expressions;
using LotoBackend.Domain.Entities;

namespace LotoBackend.Application.Common.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<Guid> AddAsync
        (
            TEntity entity,
            CancellationToken cancellationToken = default
        );

        Task<TEntity> GetByFilterAsync
        (
            Expression<Func<TEntity, bool>> filter,
            CancellationToken cancellationToken = default
        );

        Task<TEntity> GetByIdAsync
        (
           Guid id,
           CancellationToken cancellationToken = default
        );

        Task<IEnumerable<TEntity>> GetListByFilterAsync
        (
           Expression<Func<TEntity, bool>> filter,
           CancellationToken cancellationToken = default
        );

        Task UpdateAsync
        (
            Expression<Func<TEntity, bool>> filter,
            TEntity entity,
            CancellationToken cancellationToken = default
        );

        Task<bool> DeleteByIdAsync
        (
           Guid id,
           CancellationToken cancellationToken = default
        );
    }
}
