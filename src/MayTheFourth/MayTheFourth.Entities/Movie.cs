namespace MayTheFourth.Entities
{
    public class Movie : BaseModel
    {
        public Movie()
        {
            Characters = [];
            Planets = [];
            Vehicles = [];
            Starships = [];
        }

        public string Title { get; set; } = string.Empty;
        public int Episode { get; set; }
        public string OpeningCrawl { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Producer { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Starship> Starships { get; set; }

    }
}
