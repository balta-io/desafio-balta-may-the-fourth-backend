namespace MayTheFourth.Core.Entities;

public class Vehicle
{
    public string Name { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string VehicleClass { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string Length { get; set; } = string.Empty;
    public string CostInCredits { get; set; } = string.Empty;
    public string Crew { get; set; } = string.Empty;
    public string Passengers { get; set; } = string.Empty;
    public string MaxAtmospheringSpeed { get; set; } = string.Empty;
    public string CargoCapacity { get; set; } = string.Empty;
    public string Consumables { get; set; } = string.Empty;
    public string[] Films { get; set; } = [];
    public string[] Pilots { get; set; } = [];
    public string Url { get; set; } = string.Empty;
    public string Created { get; set; } = string.Empty;
    public string Edited { get; set; } = string.Empty;
}
