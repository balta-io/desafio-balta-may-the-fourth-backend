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

            var characters = await ImportCharactersAsync(cancellationToken);

            var response = characters;

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

        private async Task<bool> ImportCharactersAsync(
            CancellationToken cancellationToken)
        {
            string charactersUrl = "https://swapi.py4e.com/api/people";

            var response = await _httpClient.GetFromJsonAsync<CharacterImport>(
                charactersUrl, cancellationToken: cancellationToken);

            var _errors = new List<int>();

            if (response?.Results.Count > 0)
            {
                int i = 0;

                foreach (var character in response.Results)
                {
                    var model = character.ConvertToModel();

                    var existCharacter = await _starWarsRepository
                        .GetCharacterByIdAsync(
                        model.CharacterId,
                        cancellationToken);

                    if (existCharacter is null)
                    {
                        var _movie = await _starWarsRepository.CreateCharacterAsync(
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

