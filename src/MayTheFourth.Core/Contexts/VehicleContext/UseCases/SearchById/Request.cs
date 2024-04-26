using MediatR;

namespace MayTheFourth.Core.Contexts.VehicleContext.UseCases.SearchById;

public record Request(Guid Id) : IRequest<Response>;