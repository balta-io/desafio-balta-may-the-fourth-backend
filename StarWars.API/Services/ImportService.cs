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

            var planets = await ImportPlanetsAsync(cancellationToken);

            var characters = await ImportCharactersAsync(cancellationToken);
            
            var movies = await ImportMoviesAsync(cancellationToken);

            return characters = movies;
        }

        private async Task<bool> ImportMoviesAsync(
            CancellationToken cancellationToken)
        {
            // Todo: Implementar os demais endpoints
            string moviesUrl = "https://swapi.py4e.com/api/films";

            var response = await _httpClient.GetFromJsonAsync<MovieImport>(
                moviesUrl, cancellationToken: cancellationToken);

            var _errors = new List<int>();

            if (response?.Results.Count > 0)
            {
                int i = 0;

                foreach (var movie in response.Results)
                {
                    var model = movie.ConvertToModel();

                    var existMovie = await _starWarsRepository
                        .GetMovieByIdAsync(
                        model.MovieId,
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
                        var _character = await _starWarsRepository.CreateCharacterAsync(
                                              model, cancellationToken);

                        if (_character is null)
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

        private async Task<bool> ImportPlanetsAsync(
            CancellationToken cancellationToken)
        {
            string planetsUrl = "https://swapi.py4e.com/api/planets";

            var response = await _httpClient.GetFromJsonAsync<PlanetImport>(
                planetsUrl, cancellationToken: cancellationToken);

            var _errors = new List<int>();

            if (response?.Results.Count > 0)
            {
                int i = 0;

                foreach (var planet in response.Results)
                {
                    var model = planet.ConvertToModel();

                    var existPlanet = await _starWarsRepository
                        .GetPlanetByIdAsync(
                        model.PlanetId,
                        cancellationToken);

                    if (existPlanet is null)
                    {
                        var _planet = await _starWarsRepository.CreatePlanetAsync(
                                              model, cancellationToken);

                        if (_planet is null)
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

