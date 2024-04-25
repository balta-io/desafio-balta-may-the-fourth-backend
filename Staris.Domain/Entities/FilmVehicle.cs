
namespace Staris.Domain.Entities
{
    public sealed class FilmVehicle
	{
        public int VehicleId { get; set; }
        public int FilmId { get; set; }


        //EF Relation
        public Vehicle? Vehicle { get; init; }
        public Film? Film { get; init; }
    }
}
