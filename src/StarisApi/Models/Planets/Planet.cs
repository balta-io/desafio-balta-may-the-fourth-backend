namespace StarisApi.Models.Planets;

public class Planet
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Diameter { get; set; } = null!;
    public string RotationSpeed { get; set; } = null!;
    public string OrbitalPeriod { get; set; } = null!;
    public string Gravity { get; set; } = null!;
    public string Population { get; set; } = null!;
    public string Climate { get; set; } = null!;
    public string Terrain { get; set; } = null!;
    public string SurfaceWater { get; set; } = null!;
    //public ICollection<CharacterPlanet> Characters { get; set; } = [];
    //public ICollection<MoviePlanet> Movies { get; set; } = [];
}
