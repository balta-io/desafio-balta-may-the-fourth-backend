using MayTheFourth.Entities;
using MayTheFourth.Utils.Paging;
using System.Linq.Expressions;

namespace MayTheFourth.Repositories.Repositories.Interfaces
{
    public interface IBaseReaderRepository<T> : IDisposable where T : BaseModel
    {
        IOrderedQueryable<T> QuerySorted(IQueryable<T> source);
        Task<PageListResult<T>> GetAllPagedAsync(int page, int pageSize, CancellationToken cancellation);
        Task<PageListResult<T>> GetAllPagedFilteredAsync(int page, int pageSize, Expression<Func<T, bool>> expr, CancellationToken cancellation);        
        Task<T?> GetByKeyAsync(Expression<Func<T, bool>> expr, CancellationToken cancellation);
        Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> expr, CancellationToken cancellation);
    }
}
