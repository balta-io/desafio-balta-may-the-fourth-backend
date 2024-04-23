using MayTheFourth.Entities;

namespace MayTheFourth.Repositories.Repositories.Interfaces
{
    public interface IVehicleRepository :
        IBaseReaderRepository<Vehicle>,
        IBaseWriterRepository<Vehicle>
    {
    }
}
