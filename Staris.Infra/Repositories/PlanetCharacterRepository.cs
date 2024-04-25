using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class PlanetCharacterRepository : Repository<PlanetCharacter>, IPlanetCharacterRepository
	{
		public PlanetCharacterRepository(ApplicationDbContext context) : base(context)
		{
		}
	}

}
