

namespace Staris.Domain.Entities
{
    public sealed class StarshipFilm
    {
        public int VehicleId { get; set; } //ok?
        public int FilmId { get; set; }


        //EF Relation
        public Starship? Starship { get; set; }
        public Film? Film { get; set; }



    }
}
