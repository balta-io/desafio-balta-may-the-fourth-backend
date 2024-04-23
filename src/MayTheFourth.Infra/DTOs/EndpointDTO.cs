using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MayTheFourth.Infra.DTOs
{
    public class EndpointDTO
    {
        [JsonPropertyName("Endpoint")]
        public string Name { get; set; }

        [JsonPropertyName("Data")]
        public DataDTO Data { get; set; }
    }
}
