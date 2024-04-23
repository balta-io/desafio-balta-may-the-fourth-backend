using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.People.GetPeopleById
{
    public class GetPeopleByIdRequestHandler : IRequestHandler<GetPeopleByIdRequest, GetPeopleResponse>
    {
        private readonly IRepository<PersonEntity> _repository;

        public GetPeopleByIdRequestHandler(IRepository<PersonEntity> repository)
        {
            _repository = repository;
        }

        public async Task<GetPeopleResponse> Handle(GetPeopleByIdRequest request, CancellationToken cancellationToken)
        {
            var people = await _repository.GetByIdAsync(request.id);

            var result = people.Adapt<GetPeopleResponse>();

            return result;
        }
    }
}
