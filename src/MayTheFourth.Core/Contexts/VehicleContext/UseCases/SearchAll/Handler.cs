using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;

namespace MayTheFourth.Core.Contexts.VehicleContext.UseCases.SearchAllVehicles;

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
        try
        {
            vehicles = await _vehicleRepository.GetAllVehicles();
            if (vehicles is null)
                return new Response("Nenhum veículo encontrado.", 404);
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", 500);
        }
        #endregion

        #region Response
        return new Response("Uma lista de veículos foi encontrada.", new ResponseData(vehicles!));
        #endregion
    }
}