using Staris.Domain.Entities;
using Staris.Domain.Interfaces.Repositories;
using Staris.Infra.Data;

namespace Staris.Infra.Repositories
{
	public class FilmVehicleRepository : Repository<FilmVehicle>, IFilmVehicleRepository
	{
		public FilmVehicleRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
