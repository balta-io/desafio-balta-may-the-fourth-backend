using System.Linq.Expressions;
using LotoBackend.Application.Common.Repositories;
using LotoBackend.Domain.Entities;
using LotoBackend.Infrastructure.Mongo.Contexts.Interfaces;
using MongoDB.Driver;

namespace LotoBackend.Infrastructure.Mongo.Repositories
{
    public class GenericRepository<TEntity>(IMongoContext context) : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly IMongoContext _context = context;

        public virtual async Task<Guid> AddAsync
        (
            TEntity entity,
            CancellationToken cancellationToken = default
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            entity.SetInsertAt();

            await _context.GetCollection<TEntity>()
                .InsertOneAsync(entity, cancellationToken: cancellationToken);

            return entity.Id;
        }

        public virtual async Task<TEntity> GetByFilterAsync
        (
            Expression<Func<TEntity, bool>> filter,
            CancellationToken cancellationToken = default
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            var queryResut = await _context.GetCollection<TEntity>()
                .FindAsync(filter, cancellationToken: cancellationToken);

            return await queryResut.FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetByIdAsync
        (
            Guid id,
            CancellationToken cancellationToken = default
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            var queryResut = await _context.GetCollection<TEntity>()
                .FindAsync(f => f.Id == id, cancellationToken: cancellationToken);

            return await queryResut.FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetListByFilterAsync
        (
            Expression<Func<TEntity, bool>> filter,
            CancellationToken cancellationToken = default
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            var result = await _context.GetCollection<TEntity>()
                .FindAsync(filter, cancellationToken: cancellationToken);

            return await result.ToListAsync(cancellationToken);
        }

        public virtual async Task UpdateAsync
        (
            Expression<Func<TEntity, bool>> filter,
            TEntity entity,
            CancellationToken cancellationToken = default
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            entity.SetUpdateAt();

            await _context.GetCollection<TEntity>()
                .ReplaceOneAsync(filter, entity, cancellationToken: cancellationToken);
        }

        public virtual async Task<bool> DeleteByIdAsync
        (
            Guid id,
            CancellationToken cancellationToken = default
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            var queryResut = await _context.GetCollection<TEntity>()
                .DeleteOneAsync(f => f.Id == id, cancellationToken: cancellationToken);

            return queryResut.IsAcknowledged;
        }
    }
}
