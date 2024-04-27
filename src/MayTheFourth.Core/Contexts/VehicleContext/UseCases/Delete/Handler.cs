using System.Net;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;

namespace MayTheFourth.Core.Contexts.VehicleContext.UseCases.Delete;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IVehicleRepository _vehicleRepository;
    public Handler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Remove vehicle by id  
        try
        {
            var response = await _vehicleRepository.DeleteVehicleByIdAsync(request.Id, cancellationToken);
            if (response == false)
                return new Response("Erro: Veículo não encontrado.", (int)HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", (int)HttpStatusCode.InternalServerError);
        }
        #endregion

        #region Response
        return new Response($"Veículo {request.Id} removido com sucesso.", new ResponseData());
        #endregion
    }
}