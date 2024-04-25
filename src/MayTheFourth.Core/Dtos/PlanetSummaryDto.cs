using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Dtos;

public class PlanetSummaryDto
{
    public PlanetSummaryDto() { }
    public PlanetSummaryDto(Planet planet)
    {
        Id = planet.Id;
        Name = planet.Name;
        Slug = planet.Slug;
        Gravity = planet.Gravity;
        Population = planet.Population;
        Climate = planet.Climate;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Gravity { get; set; } = string.Empty;
    public int Population { get; set; }
    public string Climate { get; set; } = string.Empty;
}
