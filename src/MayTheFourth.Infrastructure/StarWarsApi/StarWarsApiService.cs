using Flurl.Http;
using MayTheFourth.Application.Common.Services;

namespace MayTheFourth.Infrastructure.StarWarsApi
{
    public class StarWarsApiService : IStarWarsApiService
    {
        public async Task<object?> SearchByUrlAsync(string apiUrl, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var response = await apiUrl.GetJsonAsync<object>(cancellationToken: cancellationToken);

                Console.WriteLine(response);

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar a API: {ex.Message}");

                return default;
            }
        }
    }
}
