namespace StarWars.API.Models
{
    public sealed class MovieModel
    {
        public MovieModel()
        {
        }

        public int MovieId { get; private set; }
        public string Title { get; private set; }
        public int EpisodeId { get; private set; }
        public string? Director { get; private set; }
        public string Producer { get; private set; }
        public string? ReleaseDate { get; private set; }
        public string? OpeningCrawl { get; private set; }
        public string? Url { get; private set; }
      
        public List<VehicleModel> Vehicles { get; set; }
		    public List<PlanetModel> planets { get; set; }
        // public List<CharacterModel> characters { get; set; }
        // public List<StarshipModel> starships { get; set; }

        public void ChanceMovieId(int movieId)
        {
            // Todo: Aplicar validações
            MovieId = movieId;
        }

        public void ChanceEpisode(int episodeId)
        {
            // Todo: Aplicar validações
            EpisodeId = episodeId;
        }

        public void ChanceTitle(string title)
        {
            // Todo: Aplicar validações
            Title = title;
        }

        public void ChanceDirector(string director)
        {
            // Todo: Aplicar validações
            Director = director;
        }

        public void ChanceProducer(string producer)
        {
            // Todo: Aplicar validações
            Producer = producer;
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
    }
}

