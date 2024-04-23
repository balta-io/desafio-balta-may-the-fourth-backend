using StarWars.API.Models;
using StarWars.API.Storages.Repositores;

namespace StarWars.API.Services
{
    public class ImportService : IImportService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ImportService> _logger;
        private readonly IStarWarsRepository _starWarsRepository;

        public ImportService(
            HttpClient httpClient,
            ILogger<ImportService> logger,
            IStarWarsRepository starWarsRepository)
        {
            _httpClient = httpClient;
            _logger = logger;
            _starWarsRepository = starWarsRepository;
        }

        public async Task<bool> ImportFromSwapiAsync(
            CancellationToken cancellationToken = default)
        {
            // Todo: Implementar os demais endpoints
            string movesUrl = "https://";

            var movies = await _httpClient.GetFromJsonAsync<List<MoveModel>>(
                movesUrl, cancellationToken: cancellationToken);

            var response = (movies?.Count ?? 0) > 0;

            return response;
        }
    }
}

