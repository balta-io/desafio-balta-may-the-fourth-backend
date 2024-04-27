using System;
using StarWars.API.Models;

namespace StarWars.API.Services
{
	public interface IStarWarsService
	{
		Task<List<MovieModel>?> GetMoviesAsync(CancellationToken cancellationToken);
		Task<MovieModel?> GetMovieByIdAsync(int moveId, CancellationToken cancellationToken);
		Task<CharacterModel?> GetCharacterByIdAsync(int characterId, CancellationToken cancellationToken);
		Task<List<CharacterModel>?> GetCharacterAsync(CancellationToken cancellationToken);
	}
}

