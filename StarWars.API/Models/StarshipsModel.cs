namespace StarWars.API.Models;

public class StarshipsModel
{

    public string? Name { get; set; }
    public string? Model { get; set; }
    public string? Manufacturer { get; set; }
    public string? Length { get; set; }
    public int MaxSpeed { get; set; }
    public int Crew { get; set; }
    public int Passengers { get; set; }
    public int CargoCapacity { get; set; }
    public double HyperDriveRating { get; set; }
    public int Mglt { get; set; }
    public string? Consumables { get; set; }
    public string? Class { get; set; }
    public List<MoveModel> Movies { get; set; }
}