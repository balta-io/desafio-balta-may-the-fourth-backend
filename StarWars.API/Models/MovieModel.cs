namespace StarWars.API.Models
{
    public sealed class MovieModel
    {
        protected MovieModel() {}

        public MovieModel(string id, string uid, string description, string title)
        {
            Create(id, uid, description, title);
        }

        public int MovieId { get; private set; }
        public string Id { get; private set; }
        public string Uid { get; private set; }
        public string Description { get; private set; }
        public string Title { get; private set; }
        public int EpisodeId { get; private set; }
        public string? Director { get; private set; }
        public string? ReleaseDate { get; private set; }
        public string? OpeningCrawl { get; private set; }
        public string? Url { get; private set; }
        public DateTime Edited { get; private set; }
        public DateTime Created { get; private set; }

        public List<VehicleModel> Vehicles { get; set; }
		public List<PlanetModel> planets { get; set; }

		// public List<CharacterModel> characters { get; set; }
		// public List<StarshipModel> starships { get; set; }

        private void Create(string id, string uid, string description, string title)
        {
            Id = id;
            Uid = uid;
            Title = title;
            MovieId = int.Parse(Uid);
            Description = description;
           
        }

        public void ChanceEpisode(int episodeId)
        {
            // Todo: Aplicar validações
            EpisodeId = episodeId;
        }

        public void ChanceDirector(string director)
        {
            // Todo: Aplicar validações
            Director = director;
        }

        public void ChanceReleaseDate(string release)
        {
            // Todo: Aplicar validações
            ReleaseDate = release;
        }

        public void ChanceOpeningCrawl(string crawl)
        {
            // Todo: Aplicar validações
            OpeningCrawl = crawl;
        }

        public void ChanceUrl(string url)
        {
            // Todo: Aplicar validações
            Url = url;
        }

        public void ChanceEdited(DateTime edited)
        {
            // Todo: Aplicar validações
            Edited = edited;
        }

        public void ChanceCreated(DateTime created)
        {
            // Todo: Aplicar validações
            Created = created;
        }
    }
}

