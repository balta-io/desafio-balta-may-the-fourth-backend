using MayTheFourth.Core.Contexts.SharedContext.Entities;

namespace MayTheFourth.Core.Entities;

public class Film : Entity
{
    public string Title { get; set; } = string.Empty;
    public int EpisodeId { get; set; }
    public string OpeningCrawl { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public DateOnly ReleaseDate { get; set; }
    public string Url { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }
    public List<Species> Species { get; set; } = [];
    public List<Starship> Starships { get; set; } = [];
    public List<Vehicle> Vehicles { get; set; } = [];
    public List<Person> Characters { get; set; } = [];
    public List<Planet> Planets { get; set; } = [];
}
