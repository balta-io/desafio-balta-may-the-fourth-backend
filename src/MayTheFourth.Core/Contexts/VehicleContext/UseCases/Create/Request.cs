using MayTheFourth.Core.Entities;
using MediatR;

namespace MayTheFourth.Core.Contexts.VehicleContext.UseCases.Create;

public record Request(
    string Name,
    string Model,
    string VehicleClass,
    string Manufacturer,
    int Length,
    decimal CostInCredits,
    string Crew,
    int Passengers,
    int MaxAtmospheringSpeed,
    int CargoCapacity,
    string Consumables,
    List<Film> Films,
    List<Person> Pilots,
    DateTime Created,
    DateTime Edited,
    string Url) : IRequest<Response>;