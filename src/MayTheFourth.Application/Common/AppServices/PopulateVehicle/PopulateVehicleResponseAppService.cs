using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayTheFourth.Application.Common.AppServices.PopulateVehicle;
using MayTheFourth.Application.Features;
using MayTheFourth.Application.Features.Vehicles;
using MayTheFourth.Domain.Entities;

namespace MayTheFourth.Application.Common.AppServices.PopulateEntity
{
    public class PopulateVehicleResponseAppService : IPopulateVehicleResponseAppService
    {
        public List<MoviesDescriptionToVehicle>? GetMoviesList(VehicleEntity vehicleEntity, IEnumerable<FilmEntity> filmList)
        {
            var films = new List<MoviesDescriptionToVehicle>();

            foreach(var item in vehicleEntity.Films!)
            {
                var entity = filmList.FirstOrDefault(x => x.Url.Equals(item));

                if (entity is null)
                    continue;

                var id = entity.Url.TrimEnd('/').Split('/');
                string idString = id[^1];

                films.Add(new MoviesDescriptionToVehicle()
                {
                    Id = Convert.ToInt32(idString),
                    Title = entity.Title
                });
            }
            return films;
        }
    }
}
