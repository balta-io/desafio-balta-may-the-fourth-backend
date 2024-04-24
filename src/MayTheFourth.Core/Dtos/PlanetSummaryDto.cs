using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Dtos;

public class PlanetSummaryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Gravity { get; set; } = string.Empty;
    public int Population { get; set; }
    public string Climate { get; set; } = string.Empty;
}
