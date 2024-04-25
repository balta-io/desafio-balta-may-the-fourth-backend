using MediatR;

namespace MayTheFourth.Core.Contexts.PlanetContext.UseCases.SearchById;

public record Request(Guid Id) : IRequest<Response>;
