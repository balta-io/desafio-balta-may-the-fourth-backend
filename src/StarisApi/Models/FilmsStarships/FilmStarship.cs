using StarisApi.Models.Films;
using StarisApi.Models.StarShips;

namespace StarisApi.Models.FilmsStarship;

public class FilmStarship()
{
    public int Id { get; set; }
    public int FilmId { get; set; }
    public int StarshipId { get; set; }

    public Film Film { get; set; } = null!;
    public Starship Starship { get; set; } = null!;
    
}