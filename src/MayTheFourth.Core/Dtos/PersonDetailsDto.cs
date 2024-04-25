using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Dtos;

public class PersonDetailsDto
{
    public PersonDetailsDto(Person person)
    {
        Id = person.Id;
        Name = person.Name;
        Slug = person.Slug;
        BirthYear = person.BirthYear;
        EyeColor = person.EyeColor;
        Gender = person.Gender;
        HairColor = person.HairColor;
        Height = person.Height;
        Mass = person.Mass;
        SkinColor = person.SkinColor;
        Created = person.Created;
        Edited = person.Edited;
        HomeworldId = person.HomeworldId;
        Films = person.Films.Select(film => new FilmSummaryDto
        {
            Id = film.Id,
            Title = film.Title,
            Director = film.Director,
            ReleaseDate = film.ReleaseDate
        }).ToList();
        Species = person.Species.Select(species => new SpeciesSummaryDto
        {
            Id = species.Id,
            Name = species.Name,
            Classification = species.Classification,
            Designation = species.Designation,
            Language = species.Language,
            HomeworldId = species.HomeworldId
        }).ToList();
        Starships = person.Starships.Select(starship => new StarshipSummaryDto
        {
            Id = starship.Id,
            Name = starship.Name,
            Model = starship.Model,
            Manufacturer = starship.Manufacturer
        }).ToList();
        Vehicles = person.Vehicles.Select(vehicle => new VehicleSummaryDto
        {
            Id = vehicle.Id,
            Name = vehicle.Name,
            Model = vehicle.Model,
            Manufacturer = vehicle.Manufacturer
        }).ToList();
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string BirthYear { get; set; } = string.Empty;
    public string EyeColor { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string HairColor { get; set; } = string.Empty;
    public int Height { get; set; }
    public string Mass { get; set; } = string.Empty;
    public string SkinColor { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }

    public Planet? Homeworld { get; set; }
    public Guid HomeworldId { get; set; }

    public List<FilmSummaryDto> Films { get; set; } = [];
    public List<SpeciesSummaryDto> Species { get; set; } = [];
    public List<StarshipSummaryDto> Starships { get; set; } = [];
    public List<VehicleSummaryDto> Vehicles { get; set; } = [];
}
