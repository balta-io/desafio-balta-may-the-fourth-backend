using MayTheFourth.Core.Entities;

namespace MayTheFourth.Core.Dtos;

public class PlanetDetailsDto
{
    public PlanetDetailsDto(Planet planet)
    {
        Id = planet.Id;
        Name = planet.Name;
        Slug = planet.Slug;
        Diameter = planet.Diameter;
        RotationPeriod = planet.RotationPeriod;
        OrbitalPeriod = planet.OrbitalPeriod;
        Gravity = planet.Gravity;
        Population = planet.Population;
        Climate = planet.Climate;
        Terrain = planet.Terrain;
        SurfaceWater = planet.SurfaceWater;
        Created = planet.Created;
        Edited = planet.Edited;
        Residents = planet.Residents.Select(resident =>  new PersonSummaryDto
        {
            Id = resident.Id,
            Name = resident.Name,
            BirthYear = resident.BirthYear,
            Gender = resident.Gender,
            HomeworldId = resident.HomeworldId
        }).ToList();
        Films = planet.Films.Select(film => new FilmSummaryDto
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
    public int Diameter { get; set; }
    public int RotationPeriod { get; set; }
    public int OrbitalPeriod { get; set; }
    public string Gravity { get; set; } = string.Empty;
    public int Population { get; set; }
    public string Climate { get; set; } = string.Empty;
    public string Terrain { get; set; } = string.Empty;
    public string SurfaceWater { get; set; } = string.Empty;
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }

    public List<PersonSummaryDto> Residents { get; set; } = [];
    public List<FilmSummaryDto> Films { get; set; } = [];
}
