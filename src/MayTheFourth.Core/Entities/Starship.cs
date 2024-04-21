using MayTheFourth.Core.Contexts.SharedContext.Entities;

namespace MayTheFourth.Core.Entities;

public class Starship : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string StarshipClass { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public int CostInCredits { get; set; }
    public double Length { get; set; }
    public int Crew { get; set; }
    public int Passengers { get; set; }
    public int MaxAtmospheringSpeed { get; set; }
    public string HyperdriveRating { get; set; } = string.Empty;
    public string MGLT { get; set; } = string.Empty;
    public int CargoCapacity { get; set; }
    public string Consumables { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }
    public List<Film> Films { get; set; } = [];
    public List<Person> Pilots { get; set; } = [];
}
