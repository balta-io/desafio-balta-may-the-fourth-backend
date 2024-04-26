using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MayTheFourth.Application.Features.Vehicles.GetVehicleById
{
    public sealed record GetVehicleByIdRequest(int id) : IRequest<GetVehicleResponse>;
}
