using StarWars.API.Models;
using StarWars.API.Storages.Repositores;

namespace StarWars.API.Services
{
    public class StarWarsService: IStarWarsService
	{
        private readonly IStarWarsRepository _starWarsRepository;

        public StarWarsService(IStarWarsRepository starWarsRepository)
        {
            _starWarsRepository = starWarsRepository;
        }

        public async Task<MovieModel?> GetMovieByIdAsync(int moveId, CancellationToken cancellationToken)
        {
            var movie = await _starWarsRepository.GetMovieByIdAsync(moveId, cancellationToken);

            return movie;
        }

        public async Task<List<MovieModel>?> GetMoviesAsync(CancellationToken cancellationToken)
        {
            var movies = await _starWarsRepository.GetMoviesAsync(cancellationToken);

            return movies;
        }

        public async Task<List<CharacterModel>?> GetCharacterAsync(CancellationToken cancellationToken)
        {
            var character = await _starWarsRepository.GetCharactersAsync(cancellationToken);
            return character;
        }
        public async Task<CharacterModel?> GetCharacterByIdAsync(int characterId, CancellationToken cancellationToken)
        {
            var character = await _starWarsRepository.GetCharacterByIdAsync(characterId, cancellationToken);

            return character;
        }
    }
}

