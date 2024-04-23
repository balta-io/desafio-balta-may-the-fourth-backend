using MayTheFourth.Entities;
using MayTheFourth.Repositories.Context;
using MayTheFourth.Repositories.Repositories.Interfaces;
using MayTheFourth.Utils.Paging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MayTheFourth.Repositories.Repositories
{
    public class BaseRepository<T> :
        IBaseReaderRepository<T>,
        IBaseWriterRepository<T>
        where T : BaseModel
    {
        protected readonly DatabaseContext DbConn;
        protected readonly DbSet<T> DbEntity;

        public BaseRepository(DatabaseContext context)
        {
            DbConn = context;
            DbEntity = DbConn.Set<T>();
        }

        public virtual bool Add(T model)
        {
            DbEntity.Add(model);
            return true;
        }

        public virtual bool Update(T model)
        {
            DbConn.Entry(model).State = EntityState.Modified;

            return true;
        }

        public virtual bool Remove(T model)
        {
            DbEntity.Remove(model);
            return true;
        }

        public virtual async Task<T?> RemoveByKeyAsync(Expression<Func<T, bool>> expr, CancellationToken cancellation)
        {
            var model = await DbEntity.FirstOrDefaultAsync(expr);
            if (model == null)
                return null;

            Remove(model);
            return model;
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellation) =>
            await DbConn.SaveChangesAsync(cancellation);

        public virtual IOrderedQueryable<T> QuerySorted(IQueryable<T> source) =>
            source.OrderByDescending(x => x.CreatedAt);

        protected async Task<PageListResult<T>> PaginateQuery(IQueryable<T> query, int page, int pageSize, CancellationToken cancellation)
        {
            var result = new PageListResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                HasNext = false
            };

            if (page > -1 && pageSize > 0)
            {
                var skip = (page - 1) * pageSize;
                var pageTotal = pageSize + 2;
                var preResult = await QuerySorted(query)
                    .Skip(skip)
                    .Take(pageTotal)
                    .ToListAsync(cancellation);


                result.HasNext = preResult.Count > pageSize;
                if (result.HasNext)
                    preResult.RemoveAt(preResult.Count - 1);

                result.Results = preResult;
            }
            else
            {
                result.Results = await query.ToListAsync(cancellation);
                result.CurrentPage = 1;
                result.PageSize = result.Results.Count;
            }

            return result;
        }

        public virtual async Task<PageListResult<T>> GetAllPagedAsync(int page, int pageSize, CancellationToken cancellation) =>
            await PaginateQuery(DbEntity,
                page, pageSize,
                cancellation
            );

        public virtual async Task<PageListResult<T>> GetAllPagedFilteredAsync(int page, int pageSize, Expression<Func<T, bool>> expr, CancellationToken cancellation) =>
            await PaginateQuery(
                DbEntity.Where(expr),
                page, pageSize,
                cancellation
            );

        public virtual async Task<T?> GetByKeyAsync(Expression<Func<T, bool>> expr, CancellationToken cancellation) =>
            await DbEntity.Where(expr)
                .FirstOrDefaultAsync(cancellation);

        public virtual async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> expr, CancellationToken cancellation) =>
            await DbEntity.Where(expr)
                .ToListAsync(cancellation);

        public void Dispose() => DbConn.Dispose();
    }
}
