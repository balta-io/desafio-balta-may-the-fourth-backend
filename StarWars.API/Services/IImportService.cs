namespace StarWars.API.Services
{
    public interface IImportService
	{
		/// <summary>
		/// Importação de dados na API da Star Wars
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>Retorna o valor true para indicar sucesso e false
		/// uma possivel falha</returns>
		Task<bool> FromSwapiAsync(
			CancellationToken cancellationToken = default);
	}
}

