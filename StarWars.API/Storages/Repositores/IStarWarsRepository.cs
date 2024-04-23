using StarWars.API.Models;

namespace StarWars.API.Storages.Repositores
{
    public interface IStarWarsRepository
	{
		/// <summary>
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>Retorna uma lista de filmes</returns>
		Task<List<MoveModel>?> GetMovesAsync(
			CancellationToken cancellationToken = default);

		/// <summary>
		/// Cria um novo filme
		/// </summary>
		/// <param name="model"></param>
		/// <param name="cancellationToken"></param>
		/// <returns>Retorna os dados do filme criado, em caso de sucesso</returns>
		Task<MoveModel?> CreateMove(
			MoveModel model, CancellationToken cancellationToken = default);
	}
}

