using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class PlanetRepository : Repository<Planet>, IPlanetRepository
	{
		public PlanetRepository(ApplicationDbContext context) : base(context)
		{
		}
	}

}
