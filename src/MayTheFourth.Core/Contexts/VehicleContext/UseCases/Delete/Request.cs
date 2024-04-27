using MediatR;

namespace MayTheFourth.Core.Contexts.VehicleContext.UseCases.Delete;

public record Request(Guid Id) : IRequest<Response>;