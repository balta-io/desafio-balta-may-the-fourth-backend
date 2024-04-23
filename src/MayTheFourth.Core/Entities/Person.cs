using MayTheFourth.Core.Contexts.SharedContext.Entities;
using System.Text.Json.Serialization;

namespace MayTheFourth.Core.Entities;

public class Person : Entity
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("birth_year")]
    public string BirthYear { get; set; } = string.Empty;

    [JsonPropertyName("eye_color")]
    public string EyeColor { get; set; } = string.Empty;

    [JsonPropertyName("gender")]
    public string Gender { get; set; } = string.Empty;

    [JsonPropertyName("hair_color")]
    public string HairColor { get; set; } = string.Empty;

    [JsonPropertyName("height")]
    public string Height { get; set; }

    [JsonPropertyName("mass")]
    public string Mass { get; set; } = string.Empty;

    [JsonPropertyName("skin_color")]
    public string SkinColor { get; set; } = string.Empty;

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;

    [JsonPropertyName("created")]
    public DateTime Created { get; set; }

    [JsonPropertyName("edited")]
    public DateTime Edited { get; set; }


    public Planet Homeworld { get; set; }
    public Guid HomeworldId { get; set; }

    [JsonPropertyName("films")]
    public List<Film> Films { get; set; } = [];
    public List<Species> Species { get; set; } = [];
    public List<Starship> Starships { get; set; } = [];
    public List<Vehicle> Vehicles { get; set; } = [];
}
