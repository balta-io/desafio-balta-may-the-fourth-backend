using MediatR;

namespace MayTheFourth.Core.Contexts.VehicleContext.UseCases.SearchAll;

public record Request(int PageNumber, int PageSize) : IRequest<Response>;