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
        IRepository<Film> filmRepository,
        IRepository<Person> personRepository,
        IRepository<Planet> planetRepository,
        IRepository<Specie> specieRepository,
        IRepository<Vehicle> vehicleRepository,
        IRepository<Starship> starshipRepository
    ) : IPopulateSWDataBaseAppService
    {
        private readonly IStarWarsApiService _starWarsApiService = starWarsApiService;
        private readonly IRepository<Film> _filmRepository = filmRepository;
        private readonly IRepository<Person> _personRepository = personRepository;
        private readonly IRepository<Planet> _planetRepository = planetRepository;
        private readonly IRepository<Specie> _specieRepository = specieRepository;
        private readonly IRepository<Vehicle> _vehicleRepository = vehicleRepository;
        private readonly IRepository<Starship> _starshipRepository = starshipRepository;

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
            var responseList = JsonConvert.DeserializeObject<Films>(apiResponse);
            foreach (var item in responseList.Results)
            {
                await _filmRepository.AddAsync(item, cancellationToken);
            }
        }
        private async Task PopulatePeople(CancellationToken cancellationToken)
        {
            var apiResponse = await _starWarsApiService.SearchByUrlAsync(UrlPeople, cancellationToken);
            var responseList = JsonConvert.DeserializeObject<People>(apiResponse);
            foreach (var item in responseList.Results)
            {
                await _personRepository.AddAsync(item, cancellationToken);
            }
        }
        private async Task PopulatePlanets(CancellationToken cancellationToken)
        {
            var apiResponse = await _starWarsApiService.SearchByUrlAsync(UrlPlanets, cancellationToken);
            var responseList = JsonConvert.DeserializeObject<Planets>(apiResponse);
            foreach (var item in responseList.Results)
            {
                await _planetRepository.AddAsync(item, cancellationToken);
            }
        }
        private async Task PopulateSpecies(CancellationToken cancellationToken)
        {
            var apiResponse = await _starWarsApiService.SearchByUrlAsync(UrlSpecies, cancellationToken);
            var responseList = JsonConvert.DeserializeObject<Species>(apiResponse);
            foreach (var item in responseList.Results)
            {
                await _specieRepository.AddAsync(item, cancellationToken);
            }
        }
        private async Task PopulateVehicles(CancellationToken cancellationToken)
        {
            var apiResponse = await _starWarsApiService.SearchByUrlAsync(UrlVehicles, cancellationToken);
            var responseList = JsonConvert.DeserializeObject<Vehicles>(apiResponse);
            foreach (var item in responseList.Results)
            {
                await _vehicleRepository.AddAsync(item, cancellationToken);
            }
        }
        private async Task PopulateStarships(CancellationToken cancellationToken)
        {
            var apiResponse = await _starWarsApiService.SearchByUrlAsync(UrlStarships, cancellationToken);
            var responseList = JsonConvert.DeserializeObject<Starships>(apiResponse);
            foreach (var item in responseList.Results)
            {
                await _starshipRepository.AddAsync(item, cancellationToken);
            }
        }
    }
}
