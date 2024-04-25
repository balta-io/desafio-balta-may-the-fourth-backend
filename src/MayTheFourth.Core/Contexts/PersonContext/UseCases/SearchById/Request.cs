using MediatR;

namespace MayTheFourth.Core.Contexts.PersonContext.UseCases.SearchById;

public record Request(Guid Id) : IRequest<Response>;
