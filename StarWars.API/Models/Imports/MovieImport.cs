using System.Text.Json.Serialization;

namespace StarWars.API.Models.Imports
{
    public class MovieImport
    {
        public string Message { get; set; }
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Episode_id { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string Release_date { get; set; }
        public string Opening_Crawl { get; set; }
        public string Url { get; set; }
        public List<string> Characters { get; set; }
        public List<string> Planets { get; set; }
        public List<string> Starships { get; set; }
        public List<string> Vehicles { get; set; }
        public List<string> Species { get; set; }

        public MovieModel ConvertToModel()
        {
            var model = new MovieModel();

            model.ChanceMovieId(MovieId);
            model.ChanceTitle(Title);
            model.ChanceEpisode(Episode_id);
            model.ChanceDirector(Director);
            model.ChanceProducer(Producer);
            model.ChanceReleaseDate(Release_date);
            model.ChanceOpeningCrawl(Opening_Crawl);
            model.ChanceUrl(Url);

            return model;
        }
    }
}

