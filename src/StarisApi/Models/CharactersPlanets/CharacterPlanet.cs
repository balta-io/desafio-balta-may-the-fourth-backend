using StarisApi.Models.Characters;
using StarisApi.Models.Planets;

namespace StarisApi.Models.CharactersPlanets;

public class CharacterPlanet
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public int PlanetId { get; set; }

    public Character Character { get; set; } = null!;
    public Planet Planet { get; set; } = null!;


}
