using StarisApi.Models.People;
using StarisApi.Models.Planets;

namespace StarisApi.Models.PeoplePlanets;

public class PersonPlanet
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int PlanetId { get; set; }

    public Person Person { get; set; } = null!;
    public Planet Planet { get; set; } = null!;


}
