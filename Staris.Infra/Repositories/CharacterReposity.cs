using Microsoft.EntityFrameworkCore;
using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class CharacterRepository : Repository<Character>, ICharacterRepository
	{
		public CharacterRepository(ApplicationDbContext context) : base(context)
		{
		}

		public List<Character> GetAllWithFilms()
		{
			var records = Entity.AsNoTracking()
				.Include(i => i.HomeWorld)
				.ThenInclude(i => i.Movies).ToList();
			return records;
		}
	}
}
