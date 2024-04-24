using MayTheFourth.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MayTheFourth.Infra.DTOs
{
    public class FilmDTO
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("episode_id")]
        public int EpisodeId { get; set; }

        [JsonPropertyName("opening_crawl")]
        public string OpeningCrawl { get; set; } = string.Empty;

        [JsonPropertyName("director")]
        public string Director { get; set; } = string.Empty;

        [JsonPropertyName("producer")]
        public string Producer { get; set; } = string.Empty;

        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("edited")]
        public DateTime Edited { get; set; }

        [JsonPropertyName("species")]
        public List<string> SpeciesList { get; set; } = [];

        [JsonPropertyName("starships")]
        public List<string> Starships { get; set; } = [];

        [JsonPropertyName("vehicles")]
        public List<string> Vehicles { get; set; } = [];

        [JsonPropertyName("characters")]
        public List<string> Characters { get; set; } = [];

        [JsonPropertyName("planets")]
        public List<string> Planets { get; set; } = [];

    }
}
