using MediatR;

namespace MayTheFourth.Core.Contexts.FilmContext.UseCases.SearchById;

public record Request(Guid Id) : IRequest<Response>;

