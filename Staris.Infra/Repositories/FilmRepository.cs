using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class FilmRepository : Repository<Film>, IFilmRepository
	{
		public FilmRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
