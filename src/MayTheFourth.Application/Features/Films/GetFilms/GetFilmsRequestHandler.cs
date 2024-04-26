using Mapster;
using MayTheFourth.Application.Common.AppServices.PopulateEntityList;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.Films.GetFilmes
{
    public class GetFilmsRequestHandler : IRequestHandler<GetFilmsRequest, List<GetFilmsResponse>>
    {
        private readonly IRepository<FilmEntity> _filmRepository;
        private readonly IRepository<PersonEntity> _personRepository;
        private readonly IRepository<PlanetEntity> _planetRepository;
        private readonly IRepository<VehicleEntity> _vehicleRepository;
        private readonly IRepository<StarshipEntity> _starshipRepository;
        private readonly IPopulateEntitiesResponseAppService _populateEntitiesResponseAppService;

        public GetFilmsRequestHandler
        (
            IRepository<FilmEntity> filmRepository,
            IRepository<PersonEntity> personRepository,
            IRepository<PlanetEntity> planetRepository,
            IRepository<VehicleEntity> vehicleRepository,
            IRepository<StarshipEntity> starshipRepository,
            IPopulateEntitiesResponseAppService populateEntitiesResponseAppService
        )
        {
            _filmRepository = filmRepository;
            _personRepository = personRepository;
            _planetRepository = planetRepository;
            _vehicleRepository = vehicleRepository;
            _starshipRepository = starshipRepository;
            _populateEntitiesResponseAppService = populateEntitiesResponseAppService;
 
        }

        public async Task<List<GetFilmsResponse>> Handle(GetFilmsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var filmList = await _filmRepository.GetListByFilterAsync(x => x.Active, cancellationToken);
            var peopleList = await _personRepository.GetListByFilterAsync(x => x.Active, cancellationToken);
            var planetList = await _planetRepository.GetListByFilterAsync(x => x.Active, cancellationToken);
            var vehicleList = await _vehicleRepository.GetListByFilterAsync(x => x.Active, cancellationToken);
            var starshipList = await _starshipRepository.GetListByFilterAsync(x => x.Active, cancellationToken);

            var responseList = new List<GetFilmsResponse>();

            foreach (var film in filmList)
            {
                var response = film.Adapt<GetFilmsResponse>();

                response.Characters = _populateEntitiesResponseAppService.GetPeopleList(film.Characters,peopleList);
                response.Planets = _populateEntitiesResponseAppService.GetPlanetsList(film.Planets, planetList);
                response.Vehicles = _populateEntitiesResponseAppService.GetVehiclesList(film.Vehicles, vehicleList);
                response.Starships = _populateEntitiesResponseAppService.GetStarshipsList(film.Starships, starshipList);

                responseList.Add(response);
            }

            return responseList;
        }
    }
}
