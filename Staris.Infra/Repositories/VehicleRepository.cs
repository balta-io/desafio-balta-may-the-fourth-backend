using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
	{
		public VehicleRepository(ApplicationDbContext context) : base(context)
		{
		}
	}

}
