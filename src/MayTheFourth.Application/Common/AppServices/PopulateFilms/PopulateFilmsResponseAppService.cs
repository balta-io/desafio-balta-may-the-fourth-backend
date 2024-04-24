using MayTheFourth.Application.Features.Films;
using MayTheFourth.Domain.Entities;

namespace MayTheFourth.Application.Common.AppServices.PopulateFilms
{
    public class PopulateFilmsResponseAppService : IPopulateFilmsResponseAppService
    {
        public List<ItemDescription>? GetPeopleList(FilmEntity film, IEnumerable<PersonEntity> peopleList)
        {
            var characters = new List<ItemDescription>();

            foreach (var item in film.Characters!)
            {
                var entity = peopleList.FirstOrDefault(x => x.Url.Equals(item));

                if (entity is null)
                    continue;

                var id = entity.Url.TrimEnd('/').Split('/');
                string idString = id[^1];

                characters.Add(new ItemDescription()
                {
                    Id = Convert.ToInt32(idString),
                    Name = entity.Name
                });
            }

            return characters;
        }

        public List<ItemDescription>? GetPlanetsList(FilmEntity film, IEnumerable<PlanetEntity> planetList)
        {
            var planets = new List<ItemDescription>();

            foreach (var item in film.Planets!)
            {
                var entity = planetList.FirstOrDefault(x => x.Url.Equals(item));

                if (entity is null)
                    continue;

                var id = entity.Url.TrimEnd('/').Split('/');
                string idString = id[^1];

                planets.Add(new ItemDescription()
                {
                    Id = Convert.ToInt32(idString),
                    Name = entity.Name
                });
            }

            return planets;
        }

        public List<ItemDescription>? GetVehiclesList(FilmEntity film, IEnumerable<VehicleEntity> vehicleList)
        {
            var vehicles = new List<ItemDescription>();

            foreach (var item in film.Vehicles!)
            {
                var entity = vehicleList.FirstOrDefault(x => x.Url.Equals(item));

                if (entity is null)
                    continue;

                var id = entity.Url.TrimEnd('/').Split('/');
                string idString = id[^1];

                vehicles.Add(new ItemDescription()
                {
                    Id = Convert.ToInt32(idString),
                    Name = entity.Name
                });
            }

            return vehicles;
        }

        public List<ItemDescription>? GetStarshipsList(FilmEntity film, IEnumerable<StarshipEntity> starshipList)
        {
            var starships = new List<ItemDescription>();

            foreach (var item in film.Starships!)
            {
                var entity = starshipList.FirstOrDefault(x => x.Url.Equals(item));

                if (entity is null)
                    continue;

                var id = entity.Url.TrimEnd('/').Split('/');
                string idString = id[^1];

                starships.Add(new ItemDescription()
                {
                    Id = Convert.ToInt32(idString),
                    Name = entity.Name
                });
            }

            return starships;
        }
    }
}
