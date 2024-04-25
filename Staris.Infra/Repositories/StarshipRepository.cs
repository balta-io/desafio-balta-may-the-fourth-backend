using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class StarshipRepository : Repository<Starship>, IStarshipRepository
	{
		public StarshipRepository(ApplicationDbContext context) : base(context)
		{
		}
	}

}
