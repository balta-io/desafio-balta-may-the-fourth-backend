namespace MayTheFourth.Entities
{
    public class Starship : BaseModel
    {
        public Starship()
        {
            Movies = [];
        }

        public string Name { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string CostInCredits { get; set; } = string.Empty;
        public string Length { get; set; } = string.Empty;
        public string MaxSpeed { get; set; } = string.Empty;
        public string Crew { get; set; } = string.Empty;
        public string Passengers { get; set; } = string.Empty;
        public string CargoCapacity { get; set; } = string.Empty;
        public string HyperdriveRating { get; set; } = string.Empty;
        public string MGLT { get; set; } = string.Empty;
        public string Consumables { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public ICollection<Movie> Movies { get; set; }
    }
}
