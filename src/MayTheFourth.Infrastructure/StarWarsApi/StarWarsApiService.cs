using MayTheFourth.Application.Common.Services;

namespace MayTheFourth.Infrastructure.StarWarsApi
{
    public class StarWarsApiService : IStarWarsApiService
    {
        public async Task<string?> SearchByUrlAsync(string apiUrl, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();


            try
            {
                var handler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };

                using var httpClient = new HttpClient(handler);

                var response = await httpClient.GetStringAsync(apiUrl, cancellationToken);
                Console.WriteLine(response);

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Erro ao consultar a API no endereço: {apiUrl} \n" +
                    $"Mensagem: {ex.Message}");

                return default;
            }
        }
    }
}
