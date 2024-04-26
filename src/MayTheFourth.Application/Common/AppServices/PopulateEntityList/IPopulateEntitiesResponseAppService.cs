using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MayTheFourth.Application.Common.ClassBase;
using MayTheFourth.Application.Features.Films;
using MayTheFourth.Domain.Entities;

namespace MayTheFourth.Application.Common.AppServices.PopulateEntityList
{
    public interface IPopulateEntitiesResponseAppService
    {
        List<ItemDescription>? GetFilmsList(List<string> urlList, IEnumerable<FilmEntity> filmList);

        List<ItemDescription>? GetPeopleList(List<string> urlList, IEnumerable<PersonEntity> peopleList);

        List<ItemDescription>? GetPlanetsList(List<string> urlList, IEnumerable<PlanetEntity> planetList);

        List<ItemDescription>? GetVehiclesList(List<string> urlList, IEnumerable<VehicleEntity> vehicleList);

        List<ItemDescription>? GetStarshipsList(List<string> urlList, IEnumerable<StarshipEntity> starshipList);
    }
}
