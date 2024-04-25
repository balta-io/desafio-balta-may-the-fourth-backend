using MayTheFourth.Core.Contexts.SharedContext.Entities;
using System.Text.Json.Serialization;

namespace MayTheFourth.Core.Entities;

public class Film : Entity
{
    public Film()
    {
        Slug = Title.ToLower().Replace(" ", "-");    
    }

    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public int EpisodeId { get; set; }
    public string OpeningCrawl { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Url { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }
    public List<Species> SpeciesList { get; set; } = [];
    public List<Starship> Starships { get; set; } = [];
    public List<Vehicle> Vehicles { get; set; } = [];
    public List<Person> Characters { get; set; } = [];
    public List<Planet> Planets { get; set; } = [];
}
