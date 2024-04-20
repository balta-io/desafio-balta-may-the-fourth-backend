namespace MayTheFourth.Backend.Entitites;

public class Vehicle
{
    public string Name { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public int CostInCredits { get; set; }
    public string Length { get; set; }
    public string MaxSpeed { get; set; }
    public int Crew { get; set; }
    public int Passengers { get; set; }
    public int CargoCapacity { get; set; }
    public string Consumables { get; set; }
    public string Class { get; set; }
    public List<Film>? Films { get; set; }
}
