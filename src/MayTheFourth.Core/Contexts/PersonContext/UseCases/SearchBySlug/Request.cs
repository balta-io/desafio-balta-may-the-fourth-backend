using MediatR;

namespace MayTheFourth.Core.Contexts.PersonContext.UseCases.SearchBySlug;

public record Request(string Slug) : IRequest<Response>;
