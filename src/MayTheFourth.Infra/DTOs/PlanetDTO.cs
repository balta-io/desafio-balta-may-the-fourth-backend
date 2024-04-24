using MayTheFourth.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MayTheFourth.Infra.DTOs
{
    public class PlanetDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        
        [JsonPropertyName("diameter")]
        public string? Diameter { get; set; }
        
        [JsonPropertyName("rotation_period")]
        public string? RotationPeriod { get; set; }

        [JsonPropertyName("orbital_period")]
        public string? OrbitalPeriod { get; set; }
        
        [JsonPropertyName("gravity")]
        public string? Gravity { get; set; }
        
        [JsonPropertyName("population")]
        public string? Population { get; set; }
        
        [JsonPropertyName("climate")]
        public string? Climate { get; set; } = string.Empty;
        
        [JsonPropertyName("terrain")]
        public string? Terrain { get; set; } = string.Empty;
       
        [JsonPropertyName("surface_water")]
        public string? SurfaceWater { get; set; } = string.Empty;
        
        [JsonPropertyName("url")]
        public string? Url { get; set; } = string.Empty;
        
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
        
        [JsonPropertyName("edited")]
        public DateTime Edited { get; set; }

        [JsonPropertyName("residents")]
        public List<string>? Residents { get; set; } = [];
        
        [JsonPropertyName("films")]
        public List<string>? Films { get; set; } = [];
    }
}
