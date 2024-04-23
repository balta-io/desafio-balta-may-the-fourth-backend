using MayTheFourth.Entities;
using System.Linq.Expressions;

namespace MayTheFourth.Repositories.Repositories.Interfaces
{
    public interface IBaseWriterRepository<T> : IDisposable where T : BaseModel
    {
        bool Add(T model);
        bool Update(T model);
        bool Remove(T model);
        Task<T?> RemoveByKeyAsync(Expression<Func<T, bool>> expr, CancellationToken cancellation);
        Task<int> SaveChangesAsync(CancellationToken cancellation);
    }
}
