using MayTheFourth.Core.Contexts.SharedContext.Entities;

namespace MayTheFourth.Core.Entities;

public class Planet : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Diameter { get; set; } = string.Empty;
    public string RotationPeriod { get; set; } = string.Empty;
    public string OrbitalPeriod { get; set; } = string.Empty;
    public double Gravity { get; set; }
    public string Population { get; set; } = string.Empty;
    public string Climate { get; set; } = string.Empty;
    public string Terrain { get; set; } = string.Empty;
    public string SurfaceWater { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }
    public List<Person> Residents { get; set; } = [];
    public List<Film> Films { get; set; } = [];
}
