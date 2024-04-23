using MayTheFourth.Entities;
using MayTheFourth.Repositories.Context;
using MayTheFourth.Repositories.Repositories.Interfaces;

namespace MayTheFourth.Repositories.Repositories
{
    public class VehicleRepository(DatabaseContext context) :
        BaseRepository<Vehicle>(context),
        IVehicleRepository
    {
    }
}
