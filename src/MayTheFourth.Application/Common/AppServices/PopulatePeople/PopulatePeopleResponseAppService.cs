using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayTheFourth.Application.Features.Films;
using MayTheFourth.Application.Features.People;
using MayTheFourth.Domain.Entities;

namespace MayTheFourth.Application.Common.AppServices.PopulatePeople
{
    public class PopulatePeopleResponseAppService : IPopulatePeopleResponseAppService
    {
        public List<ItemDescriptor>? GetMoviesList(PersonEntity character, IEnumerable<FilmEntity> filmList)
        {
            var films = new List<ItemDescriptor>();

            foreach (var item in character.Films!)
            {
                var entity = filmList.FirstOrDefault(x => x.Url.Equals(item));

                if (entity is null)
                    continue;

                var id = entity.Url.TrimEnd('/').Split('/');
                string idString = id[^1];

                films.Add(new ItemDescriptor()
                {
                    Id = Convert.ToInt32(idString),
                    Tittle = entity.Title
                });
            }

            return films;
        }
    }
}
