using MayTheFourth.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Infra.DTOs
{
    public static class EntitiesExtensions
    {
        public static Person ToPerson(this PersonDTO dto)
        {

            var person = new Person
            {
                Name = dto.Name,
                BirthYear = dto.BirthYear,
                EyeColor = dto.EyeColor,
                Gender = dto.Gender,
                HairColor = dto.HairColor,
                Height = int.TryParse(dto.Height, out int parsedDtoHeight) ? parsedDtoHeight : 0,
                Mass = dto.Mass,
                SkinColor = dto.SkinColor,
                Url = dto.Url,
                Created = dto.Created,
                Edited = dto.Edited
            };

            return person;
        }

        public static Planet ToPlanet(this PlanetDTO dto) 
        {
            var planet = new Planet
            {
                Name = dto.Name,
                Diameter = int.TryParse(dto.Diameter!, out int parsedDiameter) ? parsedDiameter : 0,
                RotationPeriod = int.TryParse(dto.RotationPeriod, out int parsedRotationPeriod) ? parsedRotationPeriod : 0,
                OrbitalPeriod = int.TryParse(dto.OrbitalPeriod!, out int parsedOrbitalPeriod) ? parsedOrbitalPeriod : 0,
                Gravity = dto.Gravity!,
                Population = int.TryParse(dto.Population!, out int parsedPopulation) ? parsedOrbitalPeriod : 0  ,
                Climate = dto.Climate!,
                Terrain = dto.Terrain!,
                SurfaceWater = dto.SurfaceWater!,
                Url = dto.Url!,
                Created = dto.Created,
                Edited = dto.Edited,
                Residents = new(),
                Films = new()
            };
            return planet;
        }

        public static Film ToFilm(this FilmDTO dto)
        {
            var film = new Film
            {
                Title = dto.Title,
                EpisodeId = dto.EpisodeId,
                OpeningCrawl = dto.OpeningCrawl,
                Director = dto.Director,
                Producer = dto.Producer,
                ReleaseDate = dto.ReleaseDate,
                Url = dto.Url,
                Created = dto.Created,
                Edited = dto.Edited
            };
            return film;
        }

        public static Species ToSpecies(this SpeciesDTO dto)
        {
            var species = new Species
            {
                Name = dto.Name,
                Classification = dto.Classification,
                Designation = dto.Designation,
                AverageHeight = int.TryParse(dto.AverageHeight!, out int parsedAverageHeight) ? parsedAverageHeight : 0,
                AverageLifespan = int.TryParse(dto.AverageHeight!, out int parsedAverageLifespan) ? parsedAverageLifespan : 0,
                EyeColors = dto.EyeColors,
                HairColors = dto.HairColors,
                SkinColors = dto.SkinColors,
                Language = dto.Language,
                Url = dto.Url,
                Created = dto.Created,
                Edited = dto.Edited,
            };
            return species;
        }

        public static Starship ToStarship(this StarshipDTO dto)
        {
            var starship = new Starship
            {
                Name = dto.Name,
                Model = dto.Model,
                StarshipClass = dto.StarshipClass,
                Manufacturer = dto.Manufacturer,
                CostInCredits = int.TryParse(dto.CostInCredits!, out int parsedCostInCredits) ? parsedCostInCredits : 0,
                Length = double.TryParse(dto.Length!, out double parsedLength) ? parsedLength : 0,
                Crew = int.TryParse(dto.Crew!, out int parsedCrew) ? parsedCrew : 0,
                Passengers = int.TryParse(dto.Passengers, out int parsedPassengers) ? parsedPassengers : 0,
                MaxAtmospheringSpeed = int.TryParse(dto.MaxAtmospheringSpeed, out int parsedMaxAtmospheringSpeed) ? parsedMaxAtmospheringSpeed : 0,
                HyperdriveRating = dto.HyperdriveRating,
                MGLT = dto.MGLT,
                CargoCapacity = int.TryParse(dto.CargoCapacity, out int parsedCargoCapacity) ? parsedCargoCapacity : 0,
                Consumables = dto.Consumables,
                Url = dto.Url,
                Created = dto.Created,
                Edited = dto.Edited
            };
            return starship;
        }

        public static Vehicle ToVehicle(this VehicleDTO dto)
        {
            var vehicle = new Vehicle
            {
                Name = dto.Name,
                Model = dto.Model,
                VehicleClass = dto.VehicleClass,
                Manufacturer = dto.Manufacturer,
                Length = int.TryParse(dto.Length!, out int parsedLength) ? parsedLength : 0,
                Crew =dto.Crew,
                Passengers = int.TryParse(dto.Passengers, out int parsedPassengers) ? parsedPassengers : 0,
                MaxAtmospheringSpeed = int.TryParse(dto.MaxAtmospheringSpeed, out int parsedMaxAtmospheringSpeed) ? parsedMaxAtmospheringSpeed : 0,
                CargoCapacity = int.TryParse(dto.CargoCapacity, out int parsedCargoCapacity) ? parsedCargoCapacity : 0,
                Consumables = dto.Consumables,
                Url = dto.Url,
                Created = dto.Created,
                Edited = dto.Edited
            };
            return vehicle;
        }

    }
}
