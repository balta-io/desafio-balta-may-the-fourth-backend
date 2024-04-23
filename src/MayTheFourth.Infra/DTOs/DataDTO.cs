using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MayTheFourth.Infra.DTOs
{
    public class DataDTO
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; } = string.Empty;

        
        [JsonPropertyName("previous")]
        public string Previous { get; set; } = string.Empty;


        [JsonPropertyName("results")]
        public List<Dictionary<string, object>> Results { get; set; } = new();
    }
}
