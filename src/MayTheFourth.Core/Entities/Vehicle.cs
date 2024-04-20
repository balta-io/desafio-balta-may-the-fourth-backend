namespace MayTheFourth.Core.Entities;

public class Vehicle
{
    public string Name { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string VehicleClass { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public int Length { get; set; }
    public decimal CostInCredits { get; set; }
    public string Crew { get; set; } = string.Empty;
    public int Passengers { get; set; }
    public int MaxAtmospheringSpeed { get; set; }
    public int CargoCapacity { get; set; }
    public string Consumables { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }
    public List<Film> Films { get; set; } = [];
    public List<People> Pilots { get; set; } = [];
}
