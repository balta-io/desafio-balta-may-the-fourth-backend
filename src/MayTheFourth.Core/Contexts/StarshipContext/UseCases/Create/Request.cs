using MediatR;

namespace MayTheFourth.Core.Contexts.StarshipContext.UseCases.Create;

public record Request(
    string Name,
    string Model,
    string StarshipClass,
    string Manufacturer,
    int CostInCredits,
    double Length,
    int Crew,
    int Passagers,
    int MaxAtmospheringSpeed,
    string HyperdriveRating,
    string MGLT,
    int CargoCapacity,
    string Consumables,
    string Url,
    DateTime Created,
    DateTime Edited) : IRequest<Response>;
