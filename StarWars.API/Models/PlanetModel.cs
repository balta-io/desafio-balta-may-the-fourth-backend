namespace StarWars.API.Models;

public class PlanetModel
{
    public PlanetModel()
    {
        
    }

    public int PlanetId { get; private set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public string CostInCredits { get; set; }
    public string Length { get; set; }
    public string MaxSpeed { get; set; }
    public string Crew { get; set; }
    public string Passengers { get; set; }
    public string CargoCapacity { get; set; }
    public string Consumables { get; set; }
    public string Class { get; set; }
    public List<MovieModel> Movies { get; set; }
}