using Microsoft.EntityFrameworkCore;
using Staris.Domain.Common;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;
using Staris.Infra.Helpers;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Staris.Infra.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity>
		where TEntity : class
	{
		[NotNull]
		private readonly ApplicationDbContext _context;

		[NotNull]
		protected DbSet<TEntity> Entity { get; init; }

        public Repository(ApplicationDbContext context)
        {
			_context = context;
			Entity = _context.Set<TEntity>();
		}

        public TEntity Create(TEntity entity)
		{
			var result = Entity.Add(entity);
			return result.Entity;
		}

		public TEntity Update(TEntity entity)
		{
			var result = Entity.Update(entity);
			return result.Entity;
		}

		public bool Delete(object[] keyValues)
		{
			var record = Entity.Find(keyValues);
			if (record != null)
			{
				Entity.Remove(record);
				return true;
			}
			return false;
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			var records = await Entity.AsNoTracking().ToListAsync();
			return records;
		}

		public async Task<TEntity?> GetByIdAsync(object[] keyValues)
		{
			var record = await Entity.FindAsync(keyValues);
			return record;
		}

		public async Task<PagedResult<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate, int actualPage = 1, int pageSize = 10)
		{
			var result = await Entity.AsNoTracking().Where(predicate).ToPagedResultAsync(actualPage, pageSize);
			return result;
		}

	}
}
