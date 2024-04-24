namespace MayTheFourth.Application.Common.AppServices.PopulateDB
{
    public interface IPopulateSWDataBaseAppService
    {
        Task PopulateSWDataBase(CancellationToken cancellationToken = default);
    }
}
