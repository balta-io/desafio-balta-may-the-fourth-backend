namespace May.The.Fourth.Backend.Services.Mappers
{
    public class CharacterDto
    {
        public int Id { get; set; }        
        public string Name { get; set; } = String.Empty;
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public string? HairColor { get; set; }
        public string? SkinColor { get; set; }
        public string? EyeColor { get; set; }
        public string? BirthYear { get; set; }
        public string? Gender { get; set; }
        public int? PlanetID { get; set; }    
    }
}
