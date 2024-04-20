namespace MayTheFourth.Backend.Entitites;

public class Film
{
    public string Title { get; set; }
    public int Episode { get; set; }
    public string OpeningCrawl { get; set; }
    public string Director { get; set; }
    public string Producer { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<Character>? Characters { get; set; }
    public List<Planet>? Planets { get; set; }
    public List<Vehicle>? Vehicles { get; set; }
    public List<Starship>? Starships { get; set; }
}
