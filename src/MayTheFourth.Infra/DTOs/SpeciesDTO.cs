using MayTheFourth.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MayTheFourth.Infra.DTOs
{
    public class SpeciesDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("classification")]
        public string Classification { get; set; } = string.Empty;

        [JsonPropertyName("designation")]
        public string Designation { get; set; } = string.Empty;

        [JsonPropertyName("average_height")]
        public string AverageHeight { get; set; } = string.Empty;

        [JsonPropertyName("average_lifespan")]
        public string AverageLifespan { get; set; } = string.Empty;

        [JsonPropertyName("eye_colors")]
        public string EyeColors { get; set; } = string.Empty;

        [JsonPropertyName("hair_colors")]
        public string HairColors { get; set; } = string.Empty;

        [JsonPropertyName("skin_colors")]
        public string SkinColors { get; set; } = string.Empty;

        [JsonPropertyName("language")]
        public string Language { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("edited")]
        public DateTime Edited { get; set; }

        [JsonPropertyName("homeworld")]
        public string Homeworld{ get; set; } = string.Empty;

        [JsonPropertyName("people")]
        public List<string> People { get; set; } = [];
        
        [JsonPropertyName("films")]
        public List<string> Films { get; set; } = [];

    }
}
