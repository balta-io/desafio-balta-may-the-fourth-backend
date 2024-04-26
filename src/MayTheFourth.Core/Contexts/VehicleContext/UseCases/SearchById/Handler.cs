using System.Net;
using MayTheFourth.Core.Contexts.VehicleContext.UseCases.SearchAllVehicles;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;

namespace MayTheFourth.Core.Contexts.VehicleContext.UseCases.SearchById;

public class Handler: IRequestHandler<Request, Response>
{
    private readonly IVehicleRepository _vehicleRepository;
    public Handler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Get vehicle by id
        Vehicle? vehicle;
        try
        {
            vehicle = await _vehicleRepository.GetByIdAsync(request.Id, cancellationToken);
            if (vehicle is null)
                return new Response("Veículo não encontrado.", (int)HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", (int)HttpStatusCode.InternalServerError);
        }
        #endregion

        #region Response
        return new Response("Veículo encontrado.", new ResponseData(vehicle));
        #endregion
    }
}