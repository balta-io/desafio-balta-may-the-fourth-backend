using Mapster;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.Films.GetFilmes
{
    public class GetFilmsRequestHandler : IRequestHandler<GetFilmsRequest, List<GetFilmsResponse>>
    {
        private readonly IRepository<FilmEntity> _filmRepository;
        private readonly IRepository<PersonEntity> _personRepository;

        public GetFilmsRequestHandler
        (
            IRepository<FilmEntity> filmRepository,
            IRepository<PersonEntity> personRepository
        )
        {
            _filmRepository = filmRepository;
            _personRepository = personRepository;
        }

        //private readonly IRepository<PlanetEntity> _planetRepository = planetRepository;
        //private readonly IRepository<VehicleEntity> _vehicleRepository = vehicleRepository;
        //private readonly IRepository<StarshipEntity> _starshipRepository = starshipRepository;


        public async Task<List<GetFilmsResponse>> Handle(GetFilmsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var filmList = await _filmRepository.GetListByFilterAsync(x => x.Active, cancellationToken);
            var personList = await _filmRepository.GetListByFilterAsync(x => x.Active, cancellationToken);

            var responseList = new List<GetFilmsResponse>();

            foreach (var item in filmList)
            {
                var response = item.Adapt<GetFilmsResponse>();
                var person = personList.First(x => x.Url.Equals(item.Url)).Adapt<ItemDescription>();

                response.Characters.Add(person);

                responseList.Add(response);
            }

            Console.WriteLine("FUNCIONOU");

            return responseList;
        }
    }
}
