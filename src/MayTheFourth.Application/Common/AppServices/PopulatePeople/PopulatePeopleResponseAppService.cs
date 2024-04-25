using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayTheFourth.Application.Features.People;
using MayTheFourth.Domain.Entities;
using MayTheFourth.Application.Features;

namespace MayTheFourth.Application.Common.AppServices.PopulatePeople
{
    public class PopulatePeopleResponseAppService : IPopulatePeopleResponseAppService
    {
        public List<MoviesDescriptionToPeople>? GetMoviesList(PersonEntity character, IEnumerable<FilmEntity> filmList)
        {
            var films = new List<MoviesDescriptionToPeople>();

            foreach (var item in character.Films!)
            {
                var entity = filmList.FirstOrDefault(x => x.Url.Equals(item));

                if (entity is null)
                    continue;

                var id = entity.Url.TrimEnd('/').Split('/');
                string idString = id[^1];

                films.Add(new MoviesDescriptionToPeople()
                {
                    Id = Convert.ToInt32(idString),
                    Title = entity.Title
                });
            }

            return films;
        }
    }
}
