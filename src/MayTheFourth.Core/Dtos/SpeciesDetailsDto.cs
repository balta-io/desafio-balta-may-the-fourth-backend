using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Dtos;

public class SpeciesDetailsDto
{
    public SpeciesDetailsDto(Species species)
    {
        Id = species.Id;
        Name = species.Name;
        Slug = species.Slug;
        Classification = species.Classification;
        Designation = species.Designation;
        AverageHeight = species.AverageHeight;
        AverageLifespan = species.AverageLifespan;
        EyeColors = species.EyeColors;
        HairColors = species.HairColors;
        SkinColors = species.SkinColors;
        Language = species.Language;
        Created = species.Created;
        Edited = species.Edited;
        Homeworld = species.Homeworld;
        HomeworldId = species.HomeworldId;
        People = species.People.Select(person => new PersonSummaryDto
        {
            Id = person.Id,
            Name = person.Name,
            BirthYear = person.BirthYear,
            Gender = person.Gender,
            HomeworldId = person.HomeworldId
        }).ToList();
        Films = species.Films.Select(film => new FilmSummaryDto
        {
            Id = film.Id,
            Title = film.Title,
            Director = film.Director,
            ReleaseDate = film.ReleaseDate
        }).ToList();
    }

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
