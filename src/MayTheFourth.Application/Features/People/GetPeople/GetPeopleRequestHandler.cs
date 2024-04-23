using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.People.GetPeople
{
    public class GetPeopleRequestHandler : IRequestHandler<GetPeopleRequest, List<GetPeopleResponse>>
    {
        private readonly IRepository<PersonEntity> _repository;

        public GetPeopleRequestHandler(IRepository<PersonEntity> repository)
        {
            _repository = repository;
        }


        public async Task<List<GetPeopleResponse>> Handle(GetPeopleRequest request, CancellationToken cancellationToken)
        {
            var people = await _repository.GetListByFilterAsync(x => x.Active, cancellationToken);
            var response = new List<GetPeopleResponse>();

            foreach(var person in people)
            {
                var adapt = person.Adapt<GetPeopleResponse>();
                response.Add(adapt);
            }

            var result = people.Adapt<GetPeopleResponse>();
            
            return response;
        }
    }
}
