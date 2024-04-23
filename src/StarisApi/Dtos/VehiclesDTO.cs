namespace StarisApi.Dtos
{
    public class VehiclesDTO : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string CostInCredits { get; set; } = null!;
        public string Length { get; set; } = null!;
        public string MaxSpeed { get; set; } = null!;
        public string Crew { get; set; } = null!;
        public string Passengers { get; set; } = null!;
        public string CargoCapacity { get; set; } = null!;
        public string Consumables { get; set; } = null!;
        public string ClassVehicle { get; set; } = null!;
        public ICollection<ListDto> Movies { get; set; } = null!;
    }
}