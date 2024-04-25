using MayTheFourth.Application.Features.Films;
using MayTheFourth.Domain.Entities;

namespace MayTheFourth.Application.Common.AppServices.PopulateFilms
{
    public interface IPopulateFilmsResponseAppService
    {
        List<ItemDescription>? GetFilmsList(List<string> itemDescriptions, IEnumerable<FilmEntity> peopleList);

        List<ItemDescription>? GetPeopleList(FilmEntity film, IEnumerable<PersonEntity> peopleList);

        List<ItemDescription>? GetPlanetsList(FilmEntity film, IEnumerable<PlanetEntity> planetList);

        List<ItemDescription>? GetVehiclesList(FilmEntity film, IEnumerable<VehicleEntity> vehicleList);

        List<ItemDescription>? GetStarshipsList(FilmEntity film, IEnumerable<StarshipEntity> starshipList);
    }
}
