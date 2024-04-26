using MediatR;

namespace MayTheFourth.Core.Contexts.PlanetContext.UseCases.Delete;

public record Request(Guid Id) : IRequest<Response>;
