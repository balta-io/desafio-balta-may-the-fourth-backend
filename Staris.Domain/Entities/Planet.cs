using Staris.Domain.Common;

namespace Staris.Domain.Entities;

public sealed class Planet : Entity
{
    public string Name { get; set; } = string.Empty;
    public int RotationPeriod { get; set; }
    public int OrbitalPeriod { get; set; }
    public int Diameter { get; set; }
    public string Climate { get; set; } = string.Empty;
    public int Gravity { get; set; }
    public int SurfaceWater { get; set; }
    public long Population { get; set; }


    //EF Relation
    public List<CharacterPlanet> Residents { get; set; }

	public List<PlanetFilm> Movies { get; set; }
}
