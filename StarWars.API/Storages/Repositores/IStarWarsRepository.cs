using StarWars.API.Models;

namespace StarWars.API.Storages.Repositores
{
    public interface IStarWarsRepository
	{
		/// <summary>
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>Retorna uma lista de filmes</returns>
		Task<List<MovieModel>?> GetMoviesAsync(
			CancellationToken cancellationToken = default);

        Task<MovieModel?> GetMovieByIdAsync(
            int movieId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Cria um novo filme
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Retorna os dados do filme criado, em caso de sucesso</returns>
        Task<MovieModel?> CreateMovieAsync(
			MovieModel model, CancellationToken cancellationToken = default);

		
		/// <summary>
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>Retorna uma lista de personagens</returns>
		Task<List<CharacterModel>?> GetCharactersAsync(
			CancellationToken cancellationToken = default);

        Task<CharacterModel?> GetCharacterByIdAsync(
			int characterId, 
			CancellationToken cancellationToken = default);

		Task<CharacterModel?> CreateCharacterAsync(
			CharacterModel model,  CancellationToken cancellationToken = default);

		Task<PlanetModel?> GetPlanetByIdAsync(
		   int planetId,
		   CancellationToken cancellationToken = default);

		Task<PlanetModel?> CreatePlanetAsync(
			PlanetModel model,
			CancellationToken cancellationToken = default);
		
		Task<List<VehicleModel>?> GetVehicleAsync(
			CancellationToken cancellationToken = default);
    }
}

