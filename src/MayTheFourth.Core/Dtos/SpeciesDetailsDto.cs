using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Dtos;

public class SpeciesDetailsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Classification { get; set; } = string.Empty;
    public string Designation { get; set; } = string.Empty;
    public int AverageHeight { get; set; }
    public int AverageLifespan { get; set; }
    public string EyeColors { get; set; } = string.Empty;
    public string HairColors { get; set; } = string.Empty;
    public string SkinColors { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }

    public Planet? Homeworld { get; set; }
    public Guid? HomeworldId { get; set; }


    public List<PersonSummaryDto> People { get; set; } = [];
    public List<FilmSummaryDto> Films { get; set; } = [];
}
