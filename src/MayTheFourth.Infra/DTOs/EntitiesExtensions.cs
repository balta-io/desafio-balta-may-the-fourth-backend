using MayTheFourth.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Height = dto.Height,
                Mass = dto.Mass,
                SkinColor = dto.SkinColor,
                Url = dto.Url,
                Created = dto.Created,
                Edited = dto.Edited
            };

            return person;
        }
    }
}
