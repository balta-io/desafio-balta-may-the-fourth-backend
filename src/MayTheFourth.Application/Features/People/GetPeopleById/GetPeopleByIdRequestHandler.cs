using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MayTheFourth.Application.Common.AppServices.PopulatePeople;
using MayTheFourth.Application.Common.Constants;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.People.GetPeopleById
{
    public class GetPeopleByIdRequestHandler : IRequestHandler<GetPeopleByIdRequest, GetPeopleResponse>
    {
        private readonly IRepository<PersonEntity> _repository;
        private readonly IRepository<FilmEntity> _filmRepository;
        private readonly IPopulatePeopleResponseAppService _populateService;

        public GetPeopleByIdRequestHandler(IRepository<PersonEntity> repository,IRepository<FilmEntity> filmRepository, IPopulatePeopleResponseAppService populateService)
        {
            _repository = repository;
            _filmRepository = filmRepository;
            _populateService = populateService;
        }

        public async Task<GetPeopleResponse?> Handle(GetPeopleByIdRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var url = $"{UrlConstants.UrlPeople}{request.id}/";

            var people = await _repository.GetByFilterAsync(x=>x.Url!.Equals(url) && x.Active,cancellationToken);

            if (people is null)
                return null;

            var movieList = await _filmRepository.GetListByFilterAsync(x=>x.Active,cancellationToken);

            var result = people.Adapt<GetPeopleResponse>();

            result.Movies = _populateService.GetMoviesList(people, movieList);

            return result;
        }
    }
}
