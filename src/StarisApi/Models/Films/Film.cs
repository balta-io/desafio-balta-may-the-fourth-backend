using StarisApi.Models.PeopleFilms;
using StarisApi.Models.FilmsStarship;
using StarisApi.Models.FilmsVehicle;
using StarisApi.Models.FilmsPlanet;

namespace StarisApi.Models.Films;

public class Film : Entity
{
    public string Title { get; set; } = null!;
    public int Episode { get; set; }
    public string OpeningCrawl { get; set; } = null!;
    public string Director { get; set; } = null!;
    public string Producer { get; set; } = null!;
    public string ReleaseDate { get; set; } = null!;

    public ICollection<PersonFilm> People { get; set; } = [];
    public ICollection<FilmPlanet> Planets { get; set; } = [];
    public ICollection<FilmVehicle> Vehicles { get; set; } = [];
    public ICollection<FilmStarship> Starships { get; set; } = [];

    public override T ConvertToDto<T>()
    {
        throw new NotImplementedException();
    }

    public override string GetSearchParameter()
    {
        throw new NotImplementedException();
    }
    
}
