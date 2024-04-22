using StarisApi.Models.CharactersMovies;
using StarisApi.Models.MoviesPlanet;
using StarisApi.Models.MoviesStarships;
using StarisApi.Models.MoviesVehicles;

namespace StarisApi.Models.Movies;

public class Movie : Entity
{
    public string Title { get; set; } = null!;
    public int Episode { get; set; }
    public string OpeningCrawl { get; set; } = null!;
    public string Director { get; set; } = null!;
    public string Producer { get; set; } = null!;
    public string ReleaseDate { get; set; } = null!;

    public ICollection<CharacterMovie> Characters { get; set; } = [];
    public ICollection<MoviePlanet> Planets { get; set; } = [];
    public ICollection<MovieVehicle> Vehicles { get; set; } = [];
    public ICollection<MovieStarship> Starships { get; set; } = [];

    public override T ConvertToDto<T>()
    {
        throw new NotImplementedException();
    }

    public override string GetSearchParameter()
    {
        throw new NotImplementedException();
    }
    
}
