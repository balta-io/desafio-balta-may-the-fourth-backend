namespace MayTheFourth.Application.Common.Services
{
    public interface IStarWarsApiService
    {
        Task<string?> SearchByUrlAsync(string apiUrl, CancellationToken cancellationToken = default);
    }
}
