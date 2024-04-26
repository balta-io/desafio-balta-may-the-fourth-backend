namespace MayTheFourth.Application.Features.Vehicles
{
    public class GetVehicleResponse
    {
        public string Name { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string CostInCredits { get; set; } = null!;
        public string Length { get; set; } = null!;
        public string MaxAtmospheringSpeed { get; set; } = null!;
        public string Crew { get; set; } = null!;
        public string Passengers { get; set; } = null!;
        public string CargoCapacity { get; set; } = null!;
        public string Consumables { get; set; } = null!;
        public string VehicleClass { get; set; } = null!;
        public List<MoviesDescriptionToVehicle>? Movies { get; set; } = null!;
    }

    public class MoviesDescriptionToVehicle
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
    }

}
