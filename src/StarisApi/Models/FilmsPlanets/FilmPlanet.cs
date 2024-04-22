using StarisApi.Models.Films;
using StarisApi.Models.Planets;

namespace StarisApi.Models.FilmsPlanet;

public class FilmPlanet
{
    public int Id { get; set; }
    public int FilmId { get; set; }
    public int PlanetId { get; set; }

    public Film Film { get; set; } = null!;
    public Planet Planet { get; set; } = null!;
}
