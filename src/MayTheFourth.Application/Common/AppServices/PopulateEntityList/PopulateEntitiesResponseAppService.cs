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
    public class PopulateEntitiesResponseAppService : IPopulateEntitiesResponseAppService
    {
        public List<ItemDescription>? GetFilmsList(List<string> urlList, IEnumerable<FilmEntity> filmList)
        {
            var movies = new List<ItemDescription>();

            foreach (var item in urlList!)
            {
                var entity = filmList.FirstOrDefault(x => x.Url.Equals(item));

                if (entity is null)
                    continue;

                var id = entity.Url.TrimEnd('/').Split('/');
                string idString = id[^1];

                movies.Add(new ItemDescription()
                {
                    Id = Convert.ToInt32(idString),
                    Title = entity.Title
                });
            }

            return movies;
        }

        public List<ItemDescription>? GetPeopleList(List<string> urlList, IEnumerable<PersonEntity> peopleList)
        {
            var people = new List<ItemDescription>();

            foreach (var item in urlList!)
            {
                var entity = peopleList.FirstOrDefault(x => x.Url.Equals(item));

                if (entity is null)
                    continue;

                var id = entity.Url.TrimEnd('/').Split('/');
                string idString = id[^1];

                people.Add(new ItemDescription()
                {
                    Id = Convert.ToInt32(idString),
                    Title = entity.Name
                });
            }

            return people;
        }

        public List<ItemDescription>? GetPlanetsList(List<string> urlList, IEnumerable<PlanetEntity> planetList)
        {
            var planets = new List<ItemDescription>();

            foreach (var item in urlList!)
            {
                var entity = planetList.FirstOrDefault(x => x.Url.Equals(item));

                if (entity is null)
                    continue;

                var id = entity.Url.TrimEnd('/').Split('/');
                string idString = id[^1];

                planets.Add(new ItemDescription()
                {
                    Id = Convert.ToInt32(idString),
                    Title = entity.Name
                });
            }

            return planets;
        }

        public List<ItemDescription>? GetStarshipsList(List<string> urlList, IEnumerable<StarshipEntity> starshipList)
        {
            var startShip = new List<ItemDescription>();

            foreach (var item in urlList!)
            {
                var entity = starshipList.FirstOrDefault(x => x.Url.Equals(item));

                if (entity is null)
                    continue;

                var id = entity.Url.TrimEnd('/').Split('/');
                string idString = id[^1];

                startShip.Add(new ItemDescription()
                {
                    Id = Convert.ToInt32(idString),
                    Title = entity.Name
                });
            }

            return startShip;
        }

        public List<ItemDescription>? GetVehiclesList(List<string> urlList, IEnumerable<VehicleEntity> vehicleList)
        {
            var vehicle = new List<ItemDescription>();

            foreach (var item in urlList!)
            {
                var entity = vehicleList.FirstOrDefault(x => x.Url.Equals(item));

                if (entity is null)
                    continue;

                var id = entity.Url.TrimEnd('/').Split('/');
                string idString = id[^1];

                vehicle.Add(new ItemDescription()
                {
                    Id = Convert.ToInt32(idString),
                    Title = entity.Name
                });
            }

            return vehicle;
        }
    }
}
