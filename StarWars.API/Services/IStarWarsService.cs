using System;
using StarWars.API.Models;

namespace StarWars.API.Services
{
	public interface IStarWarsService
	{
		Task<List<MoveModel>>? GetMovesAsync(CancellationToken cancellationToken);
	}
}

