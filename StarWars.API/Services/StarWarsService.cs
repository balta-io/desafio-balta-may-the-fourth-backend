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

        public async Task<List<MoveModel>?> GetMovesAsync(CancellationToken cancellationToken)
        {
            var movies = await _starWarsRepository.GetMovesAsync(cancellationToken);

            return movies;
        }
    }
}

