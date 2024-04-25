using Staris.Domain.Entities;

namespace Staris.Domain.Interfaces.Repositories
{
	public interface ICharacterRepository : IRepository<Character>
	{

		List<Character> GetAllWithFilms();
	}

}
