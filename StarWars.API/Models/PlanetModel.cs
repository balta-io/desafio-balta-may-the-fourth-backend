namespace StarWars.API.Models;

public class PlanetModel
{
    public PlanetModel()
    {
    }

    public int PlanetId { get; private set; }
    public string Name { get; private set; }
    public string RotationPeriod { get; private set; }
    public string OrbitalPeriod { get; private set; }
    public string Diameter { get; private set; }
    public string Climate { get; private set; }
    public string Gravity { get; private set; }
    public string Terrain { get; private set; }
    public string SurfaceWater { private get; set; }
    public string Population { get; private set; }
    public List<CharacterModel> characters { get; set; }
    public List<MovieModel> movies { get; set; }
}