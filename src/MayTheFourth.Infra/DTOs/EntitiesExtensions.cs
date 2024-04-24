using MayTheFourth.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
                Height = int.Parse(dto.Height),
                Mass = dto.Mass,
                SkinColor = dto.SkinColor,
                Url = dto.Url,
                Created = DateTime.Parse("2024-04-21T09:45:00Z"),
                Edited = DateTime.Parse("2024-04-21T09:45:00Z")
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

    }
}
