using System.Net;
using MayTheFourth.Core.Dtos;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;

namespace MayTheFourth.Core.Contexts.VehicleContext.UseCases.SearchAll;

public class Handler: IRequestHandler<Request, Response>
{
    private readonly IVehicleRepository _vehicleRepository;
    public Handler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Get All Vehicles
        List<Vehicle>? vehicles;
        int totalRecords;
        try
        {
            (vehicles, totalRecords) = await _vehicleRepository.GetAllAsync(request.PageNumber, request.PageSize);
            if (vehicles is null)
                return new Response("Nenhum veículo encontrado.", (int)HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", (int)HttpStatusCode.InternalServerError);
        }

        List<VehicleSummaryDto> vehicleSummaryList = vehicles.Select(vehicle => new VehicleSummaryDto(vehicle)).ToList();
        #endregion

        #region Response
        return new Response("Lista de veículos encontrada.", new ResponseData(new(vehicleSummaryList), totalRecords));
        #endregion
    }
}