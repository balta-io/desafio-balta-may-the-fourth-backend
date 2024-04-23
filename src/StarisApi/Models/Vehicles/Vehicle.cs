namespace StarisApi.Models.Vehicles;

public class Vehicle : Entity
{
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string VehicleClass { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Lenght { get; set; } = null!;
    public string CostInCredits { get; set; } = null!;
    public string Crew { get; set; } = null!;
    public string Passengers { get; set; } = null!;
    public string MaxAtmospheringSpeed { get; set; } = null!;
    public string CargoCapacity { get; set; } = null!;
    public string Consumables { get; set; } = null!;

    //public ICollection<MovieVehicle> Movies { get; set; } = [];

    public override T ConvertToDto<T>()
    {
        throw new NotImplementedException();
    }

    public override string GetSearchParameter()
    {
        throw new NotImplementedException();
    }
}
