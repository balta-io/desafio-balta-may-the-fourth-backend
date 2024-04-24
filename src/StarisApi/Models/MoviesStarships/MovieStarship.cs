using StarisApi.Models.Movies;
using StarisApi.Models.StarShips;

namespace StarisApi.Models.MoviesStarships;

public class MovieStarship()
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int StarshipId { get; set; }

    public virtual Movie Movie { get; set; } = null!;
    public virtual Starship Starship { get; set; } = null!;
    
}