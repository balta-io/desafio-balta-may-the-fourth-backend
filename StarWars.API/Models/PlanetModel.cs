namespace StarWars.API.Models;

public class PlanetModel
{
    public PlanetModel()
    {
    }

    public int PlanetId { get;  set; }
    public string Name { get;  set; }
    public string RotationPeriod { get;  set; }
    public string OrbitalPeriod { get;  set; }
    public string Diameter { get;  set; }
    public string Climate { get;  set; }
    public string Gravity { get;  set; }
    public string Terrain { get;  set; }
    public string SurfaceWater {  get;  set; }
    public string Population { get;  set; }
    public List<CharacterModel> characters { get; set; }
    public List<MovieModel> movies { get; set; }
}