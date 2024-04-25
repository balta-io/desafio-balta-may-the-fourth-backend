namespace May.The.Fourth.Backend.Services.Dtos;

    public class StarshipDto
    {
        public int Id { get; set; }        
        public string Name { get; set; } = string.Empty;
        public string? Model { get; set; }
        public string? Manufacturer { get; set; }
        public string? CostInCredits { get; set; }
        public string? Length { get; set; }
        public string? MaxSpeed { get; set; }
        public string? Crew { get; set; }
        public string? Passengers { get; set; }
        public string? CargoCapacity { get; set; }
        public string? HyperdriveRating { get; set; }
        public string? Mglt { get; set; }
        public string? Consumables { get; set; }
        public string? Class { get; set; }
    }
