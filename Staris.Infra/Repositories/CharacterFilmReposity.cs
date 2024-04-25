using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class CharacterFilmRepository : Repository<CharacterFilm>, ICharacterFilmRepository
	{
        public CharacterFilmRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
