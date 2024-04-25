using MediatR;

namespace MayTheFourth.Core.Contexts.StarshipContext.UseCases.SearchById;

public record Request(Guid Id) : IRequest<Response>;
