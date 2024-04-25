using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayTheFourth.Application.Features;
using MayTheFourth.Application.Features.Vehicles;
using MayTheFourth.Domain.Entities;

namespace MayTheFourth.Application.Common.AppServices.PopulateVehicle
{
    public interface IPopulateVehicleResponseAppService
    {
        List<MoviesDescriptionToVehicle>? GetMoviesList(VehicleEntity vehicleEntity,IEnumerable<FilmEntity> filmList);
    }
}
