using MediatR;

namespace MayTheFourth.Core.Contexts.SpeciesContext.UseCases.SearchById;

public record Request(Guid Id) : IRequest<Response>;
