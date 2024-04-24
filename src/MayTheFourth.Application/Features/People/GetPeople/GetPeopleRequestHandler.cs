using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MayTheFourth.Application.Common.AppServices.PopulateFilms;
using MayTheFourth.Application.Common.AppServices.PopulatePeople;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.People.GetPeople
{
    public class GetPeopleRequestHandler : IRequestHandler<GetPeopleRequest, List<GetPeopleResponse>>
    {
        private readonly IRepository<FilmEntity> _filmRepository;
        private readonly IRepository<PersonEntity> _repository;
        private readonly IPopulatePeopleResponseAppService _populateService;

        public GetPeopleRequestHandler(IRepository<PersonEntity> repository, IRepository<FilmEntity> filmRepository, IPopulatePeopleResponseAppService populateService)
        {
            _repository = repository;
            _filmRepository = filmRepository;
            _populateService = populateService;
        }


        public async Task<List<GetPeopleResponse>> Handle(GetPeopleRequest request, CancellationToken cancellationToken)
        {
            var people = await _repository.GetListByFilterAsync(x => x.Active, cancellationToken);
            var filmList = await _filmRepository.GetListByFilterAsync(x => x.Active, cancellationToken);
            var responseList = new List<GetPeopleResponse>();

            foreach(var person in people)
            {
                var adapt = person.Adapt<GetPeopleResponse>();

                adapt.Movies = _populateService.GetMoviesList(person,filmList);

                responseList.Add(adapt);
            }
            
            return responseList;
        }
    }
}
