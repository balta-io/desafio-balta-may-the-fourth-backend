using MayTheFourth.Core.Contexts.SharedContext.Entities;

namespace MayTheFourth.Core.Entities;

public class Species : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Classification { get; set; } = string.Empty;
    public string Designation { get; set; } = string.Empty;
    public int AverageHeight { get; set; }
    public int AverageLifespan { get; set; }
    public string EyeColors { get; set; } = string.Empty;
    public string HairColors { get; set; } = string.Empty;
    public string SkinColors { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }

    public Planet Homeworld { get; set; }
    public int HomeworldId { get; set; }


    public List<Person> People { get; set; } = [];
    public List<Film> Films { get; set; } = [];
}
