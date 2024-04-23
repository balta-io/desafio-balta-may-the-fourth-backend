namespace MayTheFourth.Entities
{
    public class Planet : BaseModel
    {
        public Planet()
        {
            Movies = [];
            Characters = [];
        }

        public string Name { get; set; } = string.Empty;
        public string RotationPeriod { get; set; } = string.Empty;
        public string OrbitalPeriod { get; set; } = string.Empty;
        public string Diameter { get; set; } = string.Empty;
        public string Climate { get; set; } = string.Empty;
        public string Gravity { get; set; } = string.Empty;
        public string Terrain { get; set; } = string.Empty;
        public string SurfaceWater { get; set; } = string.Empty;
        public string Population { get; set; } = string.Empty;

        public ICollection<Character> Characters { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
