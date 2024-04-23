namespace MayTheFourth.Entities
{
    public class Character: BaseModel
    {
        public Character()
        {
            Movies = [];
            Planets = [];
        }

        public string Name { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string HairColor { get; set; } = string.Empty;
        public string SkinColor { get; set; } = string.Empty;
        public string EyeColor { get; set; } = string.Empty;
        public string BirthYear { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public ICollection<Movie> Movies { get; set; }
        public ICollection<Planet> Planets { get; set; }
    }
}
