using MayTheFourth.Entities;
using MayTheFourth.Services.ViewModels;
using MayTheFourth.Utils.Paging;
using System.Linq.Expressions;

namespace MayTheFourth.Services.Interfaces
{
    public interface IBaseReaderService<ViewModel, Model> : IDisposable,
        IErrorBaseService
        where ViewModel : BaseViewModel<Model>
        where Model : BaseModel
    {
        Task<PageListResult<ViewModel>> GetAllPagedAsync(int page, int pageSize, CancellationToken cancellation);
        Task<PageListResult<ViewModel>> GetAllPagedFilteredAsync(int page, int pageSize, Expression<Func<Model, bool>> expr, CancellationToken cancellation);
        Task<ViewModel?> GetByKeyAsync(Expression<Func<Model, bool>> expr, CancellationToken cancellation);
    }
}
