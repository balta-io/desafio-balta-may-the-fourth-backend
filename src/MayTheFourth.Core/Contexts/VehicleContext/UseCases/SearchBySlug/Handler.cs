using System.Net;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;

namespace MayTheFourth.Core.Contexts.VehicleContext.UseCases.SearchBySlug;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IVehicleRepository _vehicleRepository;
    public Handler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Get vehicle by slug
        Vehicle? vehicle;
        try
        {
            vehicle = await _vehicleRepository.GetBySlugAsync(request.Slug, cancellationToken);
            if (vehicle == null)
                return new Response("Erro: Veículo não encontrado.", (int)HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", (int)HttpStatusCode.InternalServerError);
        }

        #endregion

        #region Response
        return new Response("Veículo encontrado com sucesso.", new ResponseData(vehicle));
        #endregion
    }
}