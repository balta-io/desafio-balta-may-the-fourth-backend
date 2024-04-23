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
                Created = DateTime.Now,
                Edited = DateTime.Now
            };

            return person;
        }
    }
}
