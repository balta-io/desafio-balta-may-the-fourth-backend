using System.Text.Json.Serialization;

namespace StarWars.API.Models.Imports
{
    public class MovieImport
    {
        public string Message { get; set; }
        public List<Result> Result { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        public string Uid { get; set; }
        public string Description { get; set; }
        public Properties Properties { get; set; }

        public MovieModel ConvertToModel()
        {
            var model = new MovieModel(Id, Uid, Description, Properties.Title);

            model.ChanceUrl(Properties.Url);
            model.ChanceEdited(Properties.Edited);
            model.ChanceCreated(Properties.Created);
            model.ChanceDirector(Properties.Director);
            model.ChanceEpisode(Properties.Episode_id);
            model.ChanceReleaseDate(Properties.Release_date);
            model.ChanceOpeningCrawl(Properties.OpeningCrawl);

            return model;
        }
    }

    public class Properties
    {
        public string Title { get; set; }
        public int Episode_id { get; set; }
        public string Director { get; set; }
        public string Release_date { get; set; }
        public string OpeningCrawl { get; set; }
        public string Url { get; set; }
        public DateTime Edited { get; set; }
        public DateTime Created { get; set; }
        public List<string> Characters { get; set; }
        public List<string> Planets { get; set; }
        public List<string> Starships { get; set; }
        public List<string> Vehicles { get; set; }
        public List<string> Species { get; set; }
    }
}

