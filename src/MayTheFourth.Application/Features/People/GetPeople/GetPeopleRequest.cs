using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MayTheFourth.Application.Features.People.GetPeople
{
    public sealed record GetPeopleRequest : IRequest<List<GetPeopleResponse>>;
    
}
