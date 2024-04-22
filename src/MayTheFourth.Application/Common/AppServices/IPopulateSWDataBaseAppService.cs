namespace MayTheFourth.Application.Common.AppServices
{
    public interface IPopulateSWDataBaseAppService
    {
        Task PopulateSWDataBase(CancellationToken cancellationToken = default);
    }
}
