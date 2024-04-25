using StarWars.API.Models;
using StarWars.API.Models.Imports;
using StarWars.API.Storages.Repositores;

namespace StarWars.API.Services
{
    public class ImportService : IImportService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ImportService> _logger;
        private readonly IStarWarsRepository _starWarsRepository;

        public ImportService(
            ILogger<ImportService> logger,
            IStarWarsRepository starWarsRepository)
        {
            _httpClient = new HttpClient();
            _logger = logger;
            _starWarsRepository = starWarsRepository;
        }

        public async Task<bool> FromSwapiAsync(
            CancellationToken cancellationToken = default)
        {
            // Todo: Implementar os demais endpoints

            var movies = await ImportMoviesAsync(cancellationToken);

            var response = movies;

            return response;
        }

        private async Task<bool> ImportMoviesAsync(
            CancellationToken cancellationToken)
        {
            // Todo: Implementar os demais endpoints
            string moviesUrl = "https://www.swapi.tech/api/films";

            var response = await _httpClient.GetFromJsonAsync<MovieImport>(
                moviesUrl, cancellationToken: cancellationToken);

            var _errors = new List<int>();

            if (response?.Result.Count > 0)
            {
                int i = 0;

                foreach (var movie in response.Result)
                {
                    var model = movie.ConvertToModel();

                    var existMovie = await _starWarsRepository
                        .GetMovieByIdAsync(
                        int.Parse(model.Uid),
                        cancellationToken);

                    if (existMovie is null)
                    {
                        var _movie = await _starWarsRepository.CreateMovieAsync(
                                              model, cancellationToken);

                        if (_movie is null)
                        {
                            i++;
                            _errors.Add(i);
                        }
                    }
                }
            }

            var _response = (_errors?.Count ?? 0) == 0;

            return _response;
        }
    }
}

