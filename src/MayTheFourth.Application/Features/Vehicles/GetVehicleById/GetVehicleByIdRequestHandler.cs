using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MayTheFourth.Application.Common.AppServices.PopulateVehicle;
using MayTheFourth.Application.Common.Constants;
using MayTheFourth.Application.Common.Repositories;
using MayTheFourth.Application.Features.People;
using MayTheFourth.Domain.Entities;
using MediatR;

namespace MayTheFourth.Application.Features.Vehicles.GetVehicleById
{
    public class GetVehicleByIdRequestHandler : IRequestHandler<GetVehicleByIdRequest, GetVehicleResponse>
    {
        private readonly IRepository<FilmEntity> _filmRepository;
        private readonly IRepository<VehicleEntity> _vehicleRepository;
        private readonly IPopulateVehicleResponseAppService _populateVehicleAppService;

        public GetVehicleByIdRequestHandler(IRepository<FilmEntity> filmRepository, IRepository<VehicleEntity> vehicleRepository, IPopulateVehicleResponseAppService populateVehicleAppService)
        {
            _filmRepository = filmRepository;
            _vehicleRepository = vehicleRepository;
            _populateVehicleAppService = populateVehicleAppService;
        }

        public async Task<GetVehicleResponse> Handle(GetVehicleByIdRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var url = $"{UrlConstants.UrlVehicles}{request.id}/";

            var vehicle = await _vehicleRepository.GetByFilterAsync(x => x.Url.Equals(url) && x.Active, cancellationToken);

            if (vehicle is null)
                return null;

            var movieList = await _filmRepository.GetListByFilterAsync(x => x.Active, cancellationToken);

            var result = vehicle.Adapt<GetVehicleResponse>();

            result.Movies = _populateVehicleAppService.GetMoviesList(vehicle, movieList);

            return result;
        }
    }
}

