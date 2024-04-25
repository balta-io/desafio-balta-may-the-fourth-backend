using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class PlanetFilmRepository : Repository<PlanetFilm>, IPlanetFilmRepository
	{
		public PlanetFilmRepository(ApplicationDbContext context) : base(context)
		{
		}
	}

}
