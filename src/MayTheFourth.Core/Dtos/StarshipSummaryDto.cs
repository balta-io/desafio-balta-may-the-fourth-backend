using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Dtos;

public class StarshipSummaryDto
{
    public StarshipSummaryDto() { }

    public StarshipSummaryDto(Starship starship)
    {
        Id = starship.Id;
        Name = starship.Name;
        Model = starship.Model;
        Manufacturer = starship.Manufacturer;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
}
