using MayTheFourth.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MayTheFourth.Infra.DTOs
{
    public class VehicleDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("model")]
        public string Model { get; set; } = string.Empty;
        
        [JsonPropertyName("vehicle_class")]
        public string VehicleClass { get; set; } = string.Empty;

        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; } = string.Empty;

        [JsonPropertyName("length")]
        public string Length { get; set; } = string.Empty;

        [JsonPropertyName("cost_in_credits")]
        public string CostInCredits { get; set; } = string.Empty;

        [JsonPropertyName("crew")]
        public string Crew { get; set; } = string.Empty;

        [JsonPropertyName("passengers")]
        public string Passengers { get; set; } = string.Empty;

        [JsonPropertyName("max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; } = string.Empty;

        [JsonPropertyName("cargo_capacity")]
        public string CargoCapacity { get; set; } = string.Empty;

        [JsonPropertyName("consumables")]
        public string Consumables { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("edited")]
        public DateTime Edited { get; set; }


        [JsonPropertyName("films")]
        public List<string> Films { get; set; } = [];

        [JsonPropertyName("pilots")]
        public List<string> Pilots { get; set; } = [];

    }
}
