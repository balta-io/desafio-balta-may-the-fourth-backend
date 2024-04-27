using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Dtos;

public class VehicleDetailsDto
{
    public VehicleDetailsDto(Vehicle vehicle)
    {
        Id = vehicle.Id;
        Name = vehicle.Name;
        Slug = vehicle.Slug;
        Model = vehicle.Model;
        VehicleClass = vehicle.VehicleClass;
        Manufacturer = vehicle.Manufacturer;
        Length = vehicle.Length;
        CostInCredits = vehicle.CostInCredits;
        Crew = vehicle.Crew;
        Passengers = vehicle.Passengers;
        MaxAtmospheringSpeed = vehicle.MaxAtmospheringSpeed;
        CargoCapacity = vehicle.CargoCapacity;
        Consumables = vehicle.Consumables;
        Created = vehicle.Created;
        Edited = vehicle.Edited;
        Films = vehicle.Films.Select(films => new FilmSummaryDto()
        {
            Id = films.Id,
            Title = films.Title,
            Slug = films.Slug,
            Director = films.Director,
            ReleaseDate = films.ReleaseDate
        }).ToList();
        Pilots = vehicle.Pilots.Select(pilots => new PersonSummaryDto()
        {
            Id = pilots.Id,
            Name = pilots.Name,
            Slug = pilots.Slug,
            BirthYear = pilots.BirthYear,
            Gender = pilots.Gender,
            HomeworldId = pilots.HomeworldId
        }).ToList();
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string VehicleClass { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public int Length { get; set; }
    public decimal CostInCredits { get; set; }
    public string Crew { get; set; } = string.Empty;
    public int Passengers { get; set; }
    public int MaxAtmospheringSpeed { get; set; }
    public int CargoCapacity { get; set; }
    public string Consumables { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }


    public List<FilmSummaryDto> Films { get; set; } = [];
    public List<PersonSummaryDto> Pilots { get; set; } = [];
}
