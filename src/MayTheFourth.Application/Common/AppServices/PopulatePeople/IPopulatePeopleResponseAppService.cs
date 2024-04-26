using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayTheFourth.Application.Features;
using MayTheFourth.Application.Features.People;
using MayTheFourth.Domain.Entities;

namespace MayTheFourth.Application.Common.AppServices.PopulatePeople
{
    public interface IPopulatePeopleResponseAppService
    {
        List<MoviesDescriptionToPeople>? GetMoviesList(PersonEntity character,IEnumerable<FilmEntity> filmList);
    }

}
