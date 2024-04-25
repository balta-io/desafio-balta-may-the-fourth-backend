using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Dtos;

public class StarshipDetailsDto
{
    public StarshipDetailsDto(Starship starship)
    {
        Id = starship.Id;
        Name = starship.Name;
        Slug = starship.Slug;
        Model = starship.Model;
        StarshipClass = starship.StarshipClass;
        Manufacturer = starship.Manufacturer;
        CostInCredits = starship.CostInCredits;
        Length = starship.Length;
        Crew = starship.Crew;
        Passengers = starship.Passengers;
        MaxAtmospheringSpeed = starship.MaxAtmospheringSpeed;
        HyperdriveRating = starship.HyperdriveRating;
        MGLT = starship.MGLT;
        CargoCapacity = starship.CargoCapacity;
        Consumables = starship.Consumables;
        Created = starship.Created;
        Edited = starship.Edited;
        Films = starship.Films.Select(film => new FilmSummaryDto
        {
            Id = film.Id,
            Title = film.Title,
            Director = film.Director,
            ReleaseDate = film.ReleaseDate
        }).ToList();
        Pilots = starship.Pilots.Select(pilot => new PersonSummaryDto
        {
            Id = pilot.Id,
            Name = pilot.Name,
            BirthYear = pilot.BirthYear,
            Gender = pilot.Gender,
            HomeworldId = pilot.HomeworldId
        }).ToList();
    }

public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string StarshipClass { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public int CostInCredits { get; set; }
    public double Length { get; set; }
    public int Crew { get; set; }
    public int Passengers { get; set; }
    public int MaxAtmospheringSpeed { get; set; }
    public string HyperdriveRating { get; set; } = string.Empty;
    public string MGLT { get; set; } = string.Empty;
    public int CargoCapacity { get; set; }
    public string Consumables { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }

    public List<FilmSummaryDto> Films { get; set; } = [];
    public List<PersonSummaryDto> Pilots { get; set; } = [];
}
