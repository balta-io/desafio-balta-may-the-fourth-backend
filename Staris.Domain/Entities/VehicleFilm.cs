
namespace Staris.Domain.Entities
{
    public sealed class VehicleFilm
    {
        public int VehicleId { get; set; } //ok?
        public int FilmId { get; set; }


        //EF Relation
        public Vehicle? Vehicle { get; set; }
        public Film? Film { get; set; }
    }
}
