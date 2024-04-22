using Mapster;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Application.Common.Services;
using MayTheFourth.Domain.Entities;
using MayTheFourth.Domain.Models;
using Newtonsoft.Json;

namespace MayTheFourth.Application.Common.AppServices
{
    public class PopulateSWDataBaseAppService
    (
        IStarWarsApiService starWarsApiService,
        IRepository<FilmEntity> filmRepository,
        IRepository<PersonEntity> personRepository,
        IRepository<PlanetEntity> planetRepository,
        IRepository<SpecieEntity> specieRepository,
        IRepository<VehicleEntity> vehicleRepository,
        IRepository<StarshipEntity> starshipRepository
    ) : IPopulateSWDataBaseAppService
    {
        private readonly IStarWarsApiService _starWarsApiService = starWarsApiService;
        private readonly IRepository<FilmEntity> _filmRepository = filmRepository;
        private readonly IRepository<PersonEntity> _personRepository = personRepository;
        private readonly IRepository<PlanetEntity> _planetRepository = planetRepository;
        private readonly IRepository<SpecieEntity> _specieRepository = specieRepository;
        private readonly IRepository<VehicleEntity> _vehicleRepository = vehicleRepository;
        private readonly IRepository<StarshipEntity> _starshipRepository = starshipRepository;

        const string UrlFilms = "https://swapi.dev/api/films/";
        const string UrlPeople = "https://swapi.dev/api/people/";
        const string UrlPlanets = "https://swapi.dev/api/planets/";
        const string UrlSpecies = "https://swapi.dev/api/species/";
        const string UrlVehicles = "https://swapi.dev/api/vehicles/";
        const string UrlStarships = "https://swapi.dev/api/starships/";

        public async Task PopulateSWDataBase(CancellationToken cancellationToken = default)
        {
            await PopulateFilms(cancellationToken);
            await PopulatePeople(cancellationToken);
            await PopulatePlanets(cancellationToken);
            await PopulateSpecies(cancellationToken);
            await PopulateVehicles(cancellationToken);
            await PopulateStarships(cancellationToken);
        }

        private async Task PopulateFilms(CancellationToken cancellationToken)
        {
            var apiResponse = await _starWarsApiService.SearchByUrlAsync(UrlFilms, cancellationToken);
            var responseList = JsonConvert.DeserializeObject<SWApiResponse>(apiResponse);

            var itens = responseList.Count;

            for (int i = 1; i <= itens; i++)
            {
                var url = $"{UrlFilms}{i}/";

                var filmObjectJson = await _starWarsApiService.SearchByUrlAsync(url, cancellationToken);
                if (string.IsNullOrWhiteSpace(filmObjectJson))
                    continue;

                var filmModel = JsonConvert.DeserializeObject<FilmModel>(filmObjectJson);
                if (filmModel is null)
                    continue;

                var filmEntity = await _filmRepository.GetByFilterAsync(x => x.Url!.Equals(filmModel.Url), cancellationToken);

                if (filmEntity is null)
                {
                    filmEntity = filmModel.Adapt<FilmEntity>();
                    await _filmRepository.AddAsync(filmEntity, cancellationToken);
                }
                else
                {
                    filmEntity.Adapt(filmModel);
                    await _filmRepository.UpdateAsync(x => x.Url!.Equals(url), filmEntity, cancellationToken);
                }
            }
        }

        private async Task PopulatePeople(CancellationToken cancellationToken)
        {
            var apiResponse = await _starWarsApiService.SearchByUrlAsync(UrlPeople, cancellationToken);
            var responseList = JsonConvert.DeserializeObject<SWApiResponse>(apiResponse);

            var itens = responseList.Count;

            for (int i = 1; i <= itens; i++)
            {
                var url = $"{UrlPeople}{i}/";

                var peopleObjectJson = await _starWarsApiService.SearchByUrlAsync(url, cancellationToken);
                if (string.IsNullOrWhiteSpace(peopleObjectJson))
                    continue;

                var personModel = JsonConvert.DeserializeObject<PersonModel>(peopleObjectJson);
                if (personModel is null)
                    continue;

                var personEntity = await _personRepository.GetByFilterAsync(x => x.Url!.Equals(personModel.Url), cancellationToken);

                if (personEntity is null)
                {
                    personEntity = personModel.Adapt<PersonEntity>();
                    await _personRepository.AddAsync(personEntity, cancellationToken);
                }
                else
                {
                    personEntity.Adapt(personModel);
                    await _personRepository.UpdateAsync(x => x.Url!.Equals(url), personEntity, cancellationToken);
                }
            }
        }

        private async Task PopulatePlanets(CancellationToken cancellationToken)
        {
            var apiResponse = await _starWarsApiService.SearchByUrlAsync(UrlPlanets, cancellationToken);
            var responseList = JsonConvert.DeserializeObject<SWApiResponse>(apiResponse);
            var itens = responseList.Count;

            for (int i = 1; i <= itens; i++)
            {
                var url = $"{UrlPlanets}{i}/";

                var planetObjectJson = await _starWarsApiService.SearchByUrlAsync(url, cancellationToken);
                if (string.IsNullOrWhiteSpace(planetObjectJson))
                    continue;

                var planetModel = JsonConvert.DeserializeObject<PlanetModel>(planetObjectJson);
                if (planetModel is null)
                    continue;

                var planetEntity = await _planetRepository.GetByFilterAsync(x => x.Url!.Equals(planetModel.Url), cancellationToken);

                if (planetEntity is null)
                {
                    planetEntity = planetModel.Adapt<PlanetEntity>();
                    await _planetRepository.AddAsync(planetEntity, cancellationToken);
                }
                else
                {
                    planetEntity.Adapt(planetModel);
                    await _planetRepository.UpdateAsync(x => x.Url!.Equals(url), planetEntity, cancellationToken);
                }
            }
        }

        private async Task PopulateSpecies(CancellationToken cancellationToken)
        {
            var apiResponse = await _starWarsApiService.SearchByUrlAsync(UrlSpecies, cancellationToken);
            var responseList = JsonConvert.DeserializeObject<SWApiResponse>(apiResponse);
            var itens = responseList.Count;

            for (int i = 1; i <= itens; i++)
            {
                var url = $"{UrlSpecies}{i}/";

                var speciesObjectJson = await _starWarsApiService.SearchByUrlAsync(url, cancellationToken);
                if (string.IsNullOrWhiteSpace(speciesObjectJson))
                    continue;

                var specieModel = JsonConvert.DeserializeObject<SpecieModel>(speciesObjectJson);
                if (specieModel is null)
                    continue;

                var specieEntity = await _specieRepository.GetByFilterAsync(x => x.Url!.Equals(specieModel.Url), cancellationToken);

                if (specieEntity is null)
                {
                    specieEntity = specieModel.Adapt<SpecieEntity>();
                    await _specieRepository.AddAsync(specieEntity, cancellationToken);
                }
                else
                {
                    specieEntity.Adapt(specieModel);
                    await _specieRepository.UpdateAsync(x => x.Url!.Equals(url), specieEntity, cancellationToken);
                }
            }
        }

        private async Task PopulateVehicles(CancellationToken cancellationToken)
        {
            var apiResponse = await _starWarsApiService.SearchByUrlAsync(UrlVehicles, cancellationToken);
            var responseList = JsonConvert.DeserializeObject<SWApiResponse>(apiResponse);
            var itens = responseList.Count;

            for (int i = 1; i <= itens; i++)
            {
                var url = $"{UrlVehicles}{i}/";

                var vehiclesObjectJson = await _starWarsApiService.SearchByUrlAsync(url, cancellationToken);
                if (string.IsNullOrWhiteSpace(vehiclesObjectJson))
                    continue;

                var vehicleModel = JsonConvert.DeserializeObject<VehicleModel>(vehiclesObjectJson);
                if (vehicleModel is null)
                    continue;

                var vehicleEntity = await _vehicleRepository.GetByFilterAsync(x => x.Url!.Equals(vehicleModel.Url), cancellationToken);

                if (vehicleEntity is null)
                {
                    vehicleEntity = vehicleModel.Adapt<VehicleEntity>();
                    await _vehicleRepository.AddAsync(vehicleEntity, cancellationToken);
                }
                else
                {
                    vehicleEntity.Adapt(vehicleModel);
                    await _vehicleRepository.UpdateAsync(x => x.Url!.Equals(url), vehicleEntity, cancellationToken);
                }
            }
        }

        private async Task PopulateStarships(CancellationToken cancellationToken)
        {
            var apiResponse = await _starWarsApiService.SearchByUrlAsync(UrlStarships, cancellationToken);
            var responseList = JsonConvert.DeserializeObject<SWApiResponse>(apiResponse);
            var itens = responseList.Count;

            for (int i = 1; i <= itens; i++)
            {
                var url = $"{UrlStarships}{i}/";

                var starshipsObjectJson = await _starWarsApiService.SearchByUrlAsync(url, cancellationToken);
                if (string.IsNullOrWhiteSpace(starshipsObjectJson))
                    continue;

                var starshipModel = JsonConvert.DeserializeObject<StarshipModel>(starshipsObjectJson);
                if (starshipModel is null)
                    continue;

                var starshipEntity = await _starshipRepository.GetByFilterAsync(x => x.Url!.Equals(starshipModel.Url), cancellationToken);

                if (starshipEntity is null)
                {
                    starshipEntity = starshipModel.Adapt<StarshipEntity>();
                    await _starshipRepository.AddAsync(starshipEntity, cancellationToken);
                }
                else
                {
                    starshipEntity.Adapt(starshipModel);
                    await _starshipRepository.UpdateAsync(x => x.Url!.Equals(url), starshipEntity, cancellationToken);
                }
            }
        }
    }
}
