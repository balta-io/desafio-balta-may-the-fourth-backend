using MayTheFourth.Entities;
using MayTheFourth.Services.ViewModels;

namespace MayTheFourth.Services.Interfaces
{
    public interface IBaseWriterService<ViewModel, Model> : IDisposable,
        IErrorBaseService
        where ViewModel : BaseViewModel<Model>
        where Model : BaseModel
    {
        Task<ViewModel?> CreateAsync(ViewModel value, CancellationToken cancellation);
        Task<ViewModel?> ChangeAsync(ViewModel value, CancellationToken cancellation);
        Task<ViewModel?> RemoveAsync(Guid key, CancellationToken cancellation);
    }
}
