namespace StarWars.API.Models
{
    public class MovieModel
	{
		public MovieModel()
		{
		}

		public int MovieId { get; private set; }
		public string Title { get; set; }
		public int Episode { get; set; }
		public string OpeningCrawl { get; set; }
		public string Director { get; set; }
		public string Producer { get; set; }
		public string ReleaseDate { get; set; }
		public List<VehicleModel> Vehicles { get; set; }
		public List<PlanetModel> planets { get; set; }

		// public List<CharacterModel> characters { get; set; }
		// public List<StarshipModel> starships { get; set; }
	}
}

