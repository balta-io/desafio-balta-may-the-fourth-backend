using System.Net;
using MayTheFourth.Core.Entities;
using MayTheFourth.Core.Interfaces.Repositories;
using MediatR;

namespace MayTheFourth.Core.Contexts.VehicleContext.UseCases.Create;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IVehicleRepository _vehicleRepository;

    public Handler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validation
        // Need to implement a validation system
        #endregion

        #region Check if vehicle already exists
        try
        {
            var exists = await _vehicleRepository.AnyAsync(request.Name, request.Model);
            if (exists)
                return new Response("Erro: veículo já cadastrado.", (int)HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            return new Response($"Erro: {ex.Message}", (int)HttpStatusCode.InternalServerError);
        }
        #endregion

        #region Create a new person
        Vehicle? vehicle;
        try
        {
            vehicle = CreateVehicle(request);
            await _vehicleRepository.SaveAsync(vehicle, cancellationToken);
        }
        catch(Exception ex)
        {
            return new Response($"Erro: {ex.Message}", (int)HttpStatusCode.InternalServerError);
        }
        #endregion

        #region Response
        return new Response("Vehicleagem cadastrado com sucesso.", new ResponseData(vehicle));
        #endregion
    }

    private static Vehicle CreateVehicle(Request request)
    {
        var vehicle = new Vehicle
        {
            Name = request.Name,
            Model = request.Model,
            VehicleClass = request.VehicleClass,
            Manufacturer = request.Manufacturer,
            Length = request.Length,
            CostInCredits = request.CostInCredits,
            Crew = request.Crew,
            Passengers = request.Passengers,
            MaxAtmospheringSpeed = request.MaxAtmospheringSpeed,
            CargoCapacity = request.CargoCapacity,
            Consumables = request.Consumables,
            Pilots = request.Pilots,
            Films = request.Films,
            Created = request.Created,
            Edited = request.Edited,
            Url = request.Url            
        };

        return vehicle;
    }
}